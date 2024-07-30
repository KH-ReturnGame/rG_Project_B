using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kick : MonoBehaviour
{
    // private Rigidbody2D _playerRigidbody;
    [SerializeField]
    private Player _player;
    // private SpriteRenderer spriteRenderer;

    private Collider2D _playerKickCollider;
    // Start is called before the first frame update
    void Start()
    {
        // _playerRigidbody = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        _playerKickCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(_player.IsContainState(PlayerStates.Cankick))
            {
                Debug.Log("진순락찔캣맘독도킥!");
            }
            else if(!_player.IsContainState(PlayerStates.Cankick))
            {
                Debug.Log("헛발질");
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            _player.AddState(PlayerStates.Cankick);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            _player.RemoveState(PlayerStates.Cankick);
        }
    }
}
