using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;
    private Tilemap tilemap;
    private Player_Movement _playerMovement;

    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
        tilemap = GameObject.FindGameObjectWithTag("ground").GetComponent<Tilemap>();
        _playerMovement = this.GetComponentInParent<Player_Movement>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ground") && name == "ground_check") 
        {
            _player.AddState(PlayerStates.IsGround);
        }
        if (other.CompareTag("ground") && name == "wall_check")
        {
            _player.AddState(PlayerStates.IsWall);
            _playerMovement._playerRigidbody.gravityScale = 0;
            _playerMovement._playerRigidbody.velocity = new Vector2 (0,0);
            Debug.Log("벽 붙은 상태임");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //땅에서 떨어졌다고 땅감지 콜라이더가 체크하면 땅감지 해제
        if (other.CompareTag("ground") && name == "ground_check")
        {
            _player.RemoveState(PlayerStates.IsGround);    
        }
        if(other.CompareTag("ground") && name == "wall_check")
        {
            _player.RemoveState(PlayerStates.IsWall);
            _playerMovement._playerRigidbody.gravityScale = 3;
            Debug.Log("벽 안붙음");
        }
    }
}
