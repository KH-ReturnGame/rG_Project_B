using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletrigid;
    private Transform player;
    private float speed = 5f;

    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Enemy_RangedPlayerChase>().player;
    }

    void Update()
    {
        bulletrigid.AddForce(player.position * speed);
        Destroy(gameObject, 3f);
    }
}
