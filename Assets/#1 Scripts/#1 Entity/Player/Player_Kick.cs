using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kick : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private Player _player;
    private SpriteRenderer spriteRenderer;

    public Collider2D _playerKickCollider;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("킥!");
        }
    }
}
