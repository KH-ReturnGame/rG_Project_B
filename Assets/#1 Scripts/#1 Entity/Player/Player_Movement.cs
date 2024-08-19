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
    
    private float originalGravity;      // 플레이어 원래 중력
    [SerializeField] private TrailRenderer tr;

    // 벽타기 관련 변수
    public bool isWallJump;
    
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
        originalGravity = _playerRigidbody.gravityScale;
    }

    //매 프레임 실행
    void Update()
    {
        //가로 입력 체크하기 --------------------------------------------------------------------------------
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (_movementInputDirection != 0)
        {
            _recentDirection = _movementInputDirection;
        }
        // 방향전환
        if (_recentDirection != 0)
        {
            spriteRenderer.flipX = _recentDirection != 1;
        }


        //점프 코드 --------------------------------------------------------------------------------
        //땅에 있을때, 벽에 있을때
        if (Input.GetButtonDown("Jump") && _player.IsContainState(PlayerStates.CanJump))
        {
            Jump();
        }   

        // 벽슬라이드, 벽 점프 --------------------------------------------------------------------------------
        if (_player.IsContainState(PlayerStates.IsWall) && _movementInputDirection != 0)
        {
            if(!isWallJump)
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
                if(Input.GetButtonDown("Jump")) 
                {
                    _player.RemoveState(PlayerStates.IsWall);
                    isWallJump = true;
                    Debug.Log("벽점프 함");
                    if(isWallJump)
                    {
                        Jump();
                    }
                }
                // 벽타기 취소
                else
                {  
                    _player.RemoveState(PlayerStates.IsWall);
                    Debug.Log("여기냐");
                    isWallJump = false;
                }
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
    }

    
    //0.02초마다 실행  --------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        //움직임 적용
        if (!_player.IsContainState(PlayerStates.IsDashing))
        {
            ApplyMovement();
        }
    }

    private void ApplyMovement()
    {
        _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_player.IsContainState(PlayerStates.IsGround))
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
        }
        else if (_player.IsContainState(PlayerStates.IsWall))
        {
            if(spriteRenderer.flipX)
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
            }
            else
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);

            }
        }
        
    }

    public void DragonDash() // 대쉬하는거
    {
        transform.position = new Vector2(WhereToDash.transform.position.x, WhereToDash.transform.position.y);
        _playerRigidbody.velocity = Vector2.zero;
        _player.RemoveState(PlayerStates.IsDragon);
        WhereToDash.SetActive(false);
    }
}

