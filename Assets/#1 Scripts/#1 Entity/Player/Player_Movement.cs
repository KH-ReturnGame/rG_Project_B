using System.Collections;
using UnityEngine;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
/// <returns></returns>
public class Player_Movement : MonoBehaviour
{
    //플레이어
    public Rigidbody2D _playerRigidbody;
    private Player _player;
    private SpriteRenderer spriteRenderer;
    private Collider2D _playerCollider;
    
    //기본 좌우, 점프
    private float _recentDirection = 1;
    [SerializeField]
    private float _movementSpeed = 8.00f;
    private float _movementInputDirection;
    public float _jumpForce = 12.00f;
    [SerializeField] private TrailRenderer tr;
    
    //공격 대쉬
    public GameObject WhereToDash;

    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player.AddState(PlayerStates.CanDash);
        _playerCollider = GetComponent<Collider2D>();
    }

    //매 프레임 실행
    void Update()
    {
        //가로 입력 체크하기 --------------------------------------------------------------------------------
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
        if(!_player.IsContainState(PlayerStates.IsWall))
        {
            if (_movementInputDirection != 0)
            {
                _recentDirection = _movementInputDirection;
            }
            // 방향전환
            if (_recentDirection != 0)
            {
                spriteRenderer.flipX = _recentDirection != 1;
            }
        }

        //점프 코드 --------------------------------------------------------------------------------
        //땅에 있을때, 벽에 있을때
        if (Input.GetButtonDown("Jump") 
        && _player.IsContainState(PlayerStates.CanJump) 
        && !_player.IsContainState(PlayerStates.IsWall))
        {
            Jump();
        }   

        // 벽슬라이드, 벽 점프 --------------------------------------------------------------------------------
        if (_player.IsContainState(PlayerStates.IsWall))
        {
            _playerRigidbody.velocity = new Vector2(0, 0);
            if(Input.GetButtonDown("Jump")) 
            {
                WallJump();
            }
        }

        // CanJump 상태 관리 ------------------------------------------------------------------------------
        if (_player.IsContainState(PlayerStates.IsGround) || _player.IsContainState(PlayerStates.IsWall)) 
        {
            _player.AddState(PlayerStates.CanJump);
        }
        else
        {
            _player.RemoveState(PlayerStates.CanJump);
        }

        // 대쉬 상태 관리 ------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftControl) && !_player.IsContainState(PlayerStates.IsDragon))
        {
            _player.AddState(PlayerStates.IsDragon);
            WhereToDash.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && _player.IsContainState(PlayerStates.IsDragon))
        {
            _player.RemoveState(PlayerStates.IsDragon);
            WhereToDash.SetActive(false);
        }

        //촉수 경직
        /*if (playerDetect.GetAttackox() == 1)
        {
            IsDashing = true;
            StartCoroutine(DelayAction(1f));
            IsDashing = false;
        }
        IEnumerator DelayAction(float delayTime)
        {
            Debug.Log("야야야야");
        }*/
    }

    
    //0.02초마다 실행  --------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        //움직임 적용
        if (_movementInputDirection != 0)
        {
            ApplyMovement();
        }
        else if(!_player.IsContainState(PlayerStates.IsWallJumping))
        {
            _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
        }
    }

    private void ApplyMovement()
    {
        if (!_player.IsContainState(PlayerStates.IsDashing) && !_player.IsContainState(PlayerStates.IsWall) && !_player.IsContainState(PlayerStates.IsWallJumping))
        {
            _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (_player.IsContainState(PlayerStates.IsGround))
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
        }
    }

    private void WallJump()
    {
        if (_player.IsContainState(PlayerStates.IsWall))
        {
            Vector2 rayDirection = Vector3.up;// Ray 방향 (위쪽 방향)
            int layerMask = 1 << 6;
            RaycastHit2D hit;

            Debug.DrawRay(transform.position, rayDirection * 1f, Color.green);

            hit = Physics2D.Raycast(transform.position, rayDirection, 1f, layerMask);
            if(hit.collider != null)
            {
                // 위로 점프
                _playerRigidbody.AddForce(Vector2.down * 7.5f, ForceMode2D.Impulse);

                _player.RemoveState(PlayerStates.IsWall);
                StartCoroutine(DisableMovementForSeconds(0.1f));
            }  
            else
            {
                // 위로 점프
                _playerRigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                // 벽에서 반대 방향으로 힘을 줌
                _playerRigidbody.AddForce(new Vector2(-_recentDirection * 5, 0), ForceMode2D.Impulse);

                // 방향 전환
                _recentDirection = -_recentDirection;  // 최근 방향을 반대로 설정
                spriteRenderer.flipX = _recentDirection != 1;  // 스프라이트의 방향을 전환

                _player.RemoveState(PlayerStates.IsWall);
                StartCoroutine(DisableMovementForSeconds(0.15f));
            }
        }
    }
    private IEnumerator DisableMovementForSeconds(float seconds)
    {
        _player.AddState(PlayerStates.IsWallJumping); // 움직임 비활성화
        yield return new WaitForSeconds(seconds); // 지정된 시간 동안 대기
        _player.RemoveState(PlayerStates.IsWallJumping); // 다시 움직일 수 있도록 활성화
    }

    public void DragonDash() // 대쉬하는거
    {
        transform.position = new Vector2(WhereToDash.transform.position.x, WhereToDash.transform.position.y);
        _playerRigidbody.velocity = Vector2.zero;
        AudioManager.instance.PlaySFX(AudioManager.SFX_enum.Dash);
        _player.RemoveState(PlayerStates.IsDragon);
        WhereToDash.SetActive(false);
    }
}

