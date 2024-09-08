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
    void Start()
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
        // 마우스의 월드 좌표를 얻어옵니다.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z 축의 값을 고정합니다. 2D이기 때문에 Z 축은 0으로 설정합니다.
        mousePosition.z = 0;

        // 플레이어 플립이랑 방향 똑같이
        spriteRenderer.flipX = _playerfilp.flipX;

         // 플레이어와의 거리 계산
        Vector3 direction = mousePosition - _playerTransform.position;
        float distance = direction.magnitude;

        // 최대 거리를 초과할 경우
        if (distance > radius)
        {
            // 최대 거리 내에서 마우스를 따라가도록 위치를 조정
            direction = direction.normalized; // 방향 벡터를 정규화
            transform.position = _playerTransform.position + direction * radius;
        }
        else
        {
            // 최대 거리를 초과하지 않으면 마우스를 그대로 따라갑니다.
            transform.position = mousePosition;
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(_playerTransform.position, (transform.position - _playerTransform.position).normalized, distance);
        Debug.DrawLine(_playerTransform.position, transform.position, Color.red);
        
        List<GameObject> hitObjects = new List<GameObject>();
        foreach (var hit in hits)
        {
            hitObjects.Add(hit.collider.gameObject);
        }

        // 리스트에 ground 태그를 가진 오브젝트가 있는지 확인
        bool groundHit = hitObjects.Exists(obj => obj.CompareTag("ground"));
        if (groundHit)
        {
                RaycastHit2D groundRaycast = Array.Find(hits, hit => hit.collider != null && hit.collider.CompareTag("ground"));

                // ground 오브젝트와 충돌한 경우, transform의 위치를 조정하여 땅을 넘지 않도록 한다.
                Vector3 hitPoint = groundRaycast.point; // 충돌한 지점
                Vector3 normal = groundRaycast.normal; // 충돌한 표면의 법선 벡터

                // 충돌 지점과 플레이어 위치 사이의 벡터 계산
                Vector3 fromPlayerToHit = hitPoint - _playerTransform.position;

                // 땅을 넘지 않도록 충돌 지점 바로 앞에 위치를 설정
                transform.position = hitPoint + normal * 0.25f; // 땅을 넘지 않게 약간 떨어진 위치로 설정
        }

        lineRenderer.SetPosition(0, _playerTransform.position); // 첫 번째 점 (플레이어 위치)
        lineRenderer.SetPosition(1, transform.position); // 두 번째 점 (팔로우 오브젝트 위치)

        if(Input.GetMouseButtonDown(0) && isCanDash)
        {
            _playerMovement.DragonDash();
            if(groundHit)
            {
                _player.AddState(PlayerStates.IsWall);
                _playerMovement._playerRigidbody.gravityScale = 0f;
            }

            bool enemyHit = hitObjects.Exists(obj => obj.CompareTag("enemy"));
            if (enemyHit)
            {
                // 여기에 적과 충돌한 경우 처리할 로직 추가
                Debug.Log("적이 히트되었습니다!");

                // 예시: 적에게 데미지를 주는 메서드 호출 (적 오브젝트와의 상호작용)
                RaycastHit2D enemyRaycast = Array.Find(hits, hit => hit.collider != null && hit.collider.CompareTag("enemy"));
                if (enemyRaycast.collider != null)
                {
                    // 여기서 적과의 상호작용을 처리할 수 있습니다.
                    Enemy _enemy = enemyRaycast.collider.GetComponent<Enemy>();
                    if (_enemy != null)
                    {
                        _enemy.TakeDamage(50); // 예시로 적에게 데미지를 주는 메서드 호출
                    }
                }
            }
        }
    }
}