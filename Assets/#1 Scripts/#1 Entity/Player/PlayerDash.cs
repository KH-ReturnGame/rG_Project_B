using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public SpriteRenderer _playerfilp;
    public Transform _playerTransform;
    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;
    public Player_Movement _playerMovement;
    public float radius;
    private bool isCanDash;
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // 선의 시작 두께
        lineRenderer.endWidth = 0.1f; // 선의 끝 두께
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.cyan; // 선의 시작 색상
        lineRenderer.endColor = Color.cyan; // 선의 끝 색상
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

        lineRenderer.SetPosition(0, _playerTransform.position); // 첫 번째 점 (플레이어 위치)
        lineRenderer.SetPosition(1, transform.position); // 두 번째 점 (팔로우 오브젝트 위치)

        RaycastHit2D[] hits = Physics2D.RaycastAll(_playerTransform.position, transform.position, distance);
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
            isCanDash = false;
            spriteRenderer.enabled = false;
            lineRenderer.enabled = false;
            Debug.Log("Tlqkfffffffff");
        }
        else
        {
            isCanDash = true;
            spriteRenderer.enabled = true;
            lineRenderer.enabled = true;
        }

        if(Input.GetMouseButtonDown(0) && isCanDash)
        {
            _playerMovement.DragonDash();
        }
    }
}