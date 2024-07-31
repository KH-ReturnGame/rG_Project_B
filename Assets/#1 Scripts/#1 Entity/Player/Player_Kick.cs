using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kick : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private Collider2D _playerKickCollider;
    // Start is called before the first frame update
    void Start()
    {
        _playerKickCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !_player.IsContainState(PlayerStates.IsKicking))
        {
            if(_player.IsContainState(PlayerStates.Cankick))
            {
                Debug.Log("독도킥!");
                StartCoroutine(KickingCoroutine());
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
            if(_player.IsContainState(PlayerStates.IsKicking))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                Transform tf = collision.gameObject.GetComponent<Transform>();
                Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
                Vector2 direction = (tf.position - transform.position).normalized;

                rb.AddForce(direction * 300, ForceMode2D.Impulse);
                Debug.Log("진순락찔캣맘독도킥");
                _enemy.AddState(EnemyStates.IsKicked);
                _player.RemoveState(PlayerStates.IsKicking);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            _player.RemoveState(PlayerStates.Cankick);
        }
    }
    private IEnumerator KickingCoroutine()
    {
        _player.AddState(PlayerStates.IsKicking);
        
        yield return new WaitForSeconds(0.1f);

        if(_player.IsContainState(PlayerStates.IsKicking))
        {
            _player.RemoveState(PlayerStates.IsKicking);
        }
    }
}
