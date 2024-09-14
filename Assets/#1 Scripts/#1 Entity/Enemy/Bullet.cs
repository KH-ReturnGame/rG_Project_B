using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletrigid;
    public Transform player;
    private float speed = 7f;
    public Vector3 copiedPlayer;

    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player(Clone)").transform;
        copiedPlayer = player.transform.position;

        Vector2 direction = (copiedPlayer - transform.position).normalized; // 총알 향하는 방향 정하기

        bulletrigid.AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 3f); // 3초 뒤 사라짐
    }

    void Update()
    {
       


    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player") // 타일맵이나 플레이어랑 충돌하면 사라짐
        { 
            Destroy(gameObject);
            Debug.Log("Die");
        }
    }
}
