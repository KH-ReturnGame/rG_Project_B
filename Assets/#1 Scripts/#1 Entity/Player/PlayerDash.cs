using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDash : MonoBehaviour
{
    Player _player;
    public SpriteRenderer _playerfilp;
    public Transform _playerTransform;
    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;
    public Player_Movement _playerMovement;
    public float radius;
    private bool isCanDash;
    public Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player = this.transform.parent.GetComponent<Player>();

        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // 선의 시작 두께
        lineRenderer.endWidth = 0.1f; // 선의 끝 두께
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red; // 선의 시작 색상
        lineRenderer.endColor = Color.red; // 선의 끝 색상
        lineRenderer.positionCount = 2; // 두 점을 연결

        isCanDash = true;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        spriteRenderer.flipX = _playerfilp.flipX;

        Vector3 direction = mousePosition - _playerTransform.position;
        float distance = direction.magnitude;

        if (distance > radius)
        {
            direction = direction.normalized;
            transform.position = _playerTransform.position + direction * radius;
        }
        else
        {
            transform.position = mousePosition;
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(_playerTransform.position, (transform.position - _playerTransform.position).normalized, distance);
        Debug.DrawLine(_playerTransform.position, transform.position, Color.red);

        List<GameObject> hitObjects = new List<GameObject>();
        foreach (var hit in hits)
        {
            hitObjects.Add(hit.collider.gameObject);
        }

        bool groundHit = hitObjects.Exists(obj => obj.CompareTag("ground"));
        if (groundHit)
        {
            RaycastHit2D groundRaycast = Array.Find(hits, hit => hit.collider != null && hit.collider.CompareTag("ground"));
            Vector3 hitPoint = groundRaycast.point;
            Vector3 normal = groundRaycast.normal;
            Vector3 fromPlayerToHit = hitPoint - _playerTransform.position;
            transform.position = hitPoint + normal * 0.25f;
        }

        lineRenderer.SetPosition(0, _playerTransform.position);
        lineRenderer.SetPosition(1, transform.position);

        if (Input.GetMouseButtonDown(0) && isCanDash)
        {
            _playerMovement.DragonDash();

            if (groundHit)
            {
                _player.AddState(PlayerStates.IsWall);
                _playerMovement._playerRigidbody.gravityScale = 0f;
            }

            bool enemyHit = hitObjects.Exists(obj => obj.CompareTag("Enemy"));
            if (enemyHit)
            {
                RaycastHit2D enemyRaycast = Array.Find(hits, hit => hit.collider != null && hit.collider.CompareTag("Enemy"));
                if (enemyRaycast.collider != null)
                {
                    Enemy _enemy = enemyRaycast.collider.GetComponent<Enemy>();
                    if (_enemy != null)
                    {
                        _enemy.TakeDamage(50);
                        _player.RecoveryHp(15);
                    }
                }
            }
        }
    }
}
