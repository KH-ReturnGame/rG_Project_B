using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D _playerRigidbody;
    private Player _player;
    private SpriteRenderer spriteRenderer;
    private Collider2D _playerCollider;

    private float _recentDirection = 1;
    [SerializeField] private float _movementSpeed = 8.00f;
    private float _movementInputDirection;
    public float _jumpForce = 12.00f;
    [SerializeField] private TrailRenderer tr;

    public GameObject WhereToDash;
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost = false;

    void Start()
    {
        ghostDelaySeconds = ghostDelay;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player.AddState(PlayerStates.CanDash);
        _playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (!_player.IsContainState(PlayerStates.IsWall))
        {
            if (_movementInputDirection != 0)
            {
                _recentDirection = _movementInputDirection;
            }

            if (_recentDirection != 0)
            {
                spriteRenderer.flipX = _recentDirection != 1;
            }
        }

        if (Input.GetButtonDown("Jump") && _player.IsContainState(PlayerStates.CanJump) && !_player.IsContainState(PlayerStates.IsWall))
        {
            Jump();
        }

        if (_player.IsContainState(PlayerStates.IsWall))
        {
            _playerRigidbody.velocity = new Vector2(0, 0);
            if (Input.GetButtonDown("Jump"))
            {
                WallJump();
            }
        }

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
        else if (Input.GetKeyUp(KeyCode.LeftControl) && _player.IsContainState(PlayerStates.IsDragon))
        {
            _player.RemoveState(PlayerStates.IsDragon);
            WhereToDash.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_movementInputDirection != 0)
        {
            ApplyMovement();
        }
        else if (!_player.IsContainState(PlayerStates.IsWallJumping))
        {
            _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
        }
    }

    private void ApplyMovement()
    {
        if (!_player.IsContainState(PlayerStates.IsDashing) && !_player.IsContainState(PlayerStates.IsWall) &&
            !_player.IsContainState(PlayerStates.IsWallJumping))
        {
            _playerRigidbody.velocity =
                new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (_player.IsContainState(PlayerStates.IsGround))
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
        }
    }

    private void WallJump()
    {
        if (_player.IsContainState(PlayerStates.IsWall))
        {
            _playerRigidbody.AddForce(new Vector2(-_recentDirection * 5, 10), ForceMode2D.Impulse);
            _player.RemoveState(PlayerStates.IsWall);
            StartCoroutine(DisableMovementForSeconds(0.15f));
        }
    }

    private IEnumerator DisableMovementForSeconds(float seconds)
    {
        _player.AddState(PlayerStates.IsWallJumping);
        yield return new WaitForSeconds(seconds);
        _player.RemoveState(PlayerStates.IsWallJumping);
    }

    public void DragonDash()
    {
        this.makeGhost = true;
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                DragonDashSegmented();
                ghostDelaySeconds = ghostDelay;
                this.makeGhost = false;
            }
        }

        transform.position = new Vector2(WhereToDash.transform.position.x, WhereToDash.transform.position.y);
        _playerRigidbody.velocity = Vector2.zero;
        _player.RemoveState(PlayerStates.IsDragon);
        WhereToDash.SetActive(false);
    }

    public void DragonDashSegmented()
    {
        StartCoroutine(CreateGhostSegments());
    }

    private IEnumerator CreateGhostSegments()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = WhereToDash.transform.position;
        int segmentCount = 5;

        for (int i = 1; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            Vector2 spawnPos = Vector2.Lerp(startPos, endPos, t);

            GameObject currentGhost = Instantiate(ghost, spawnPos, transform.rotation);
            Destroy(currentGhost, 0.3f);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
