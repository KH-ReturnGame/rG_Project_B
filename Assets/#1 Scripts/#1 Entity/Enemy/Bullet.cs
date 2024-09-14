using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletrigid;
    public Transform player;
    private float speed = 2f;

    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player(Clone)").transform;
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        bulletrigid.AddForce(direction * speed, ForceMode2D.Force);
        Destroy(gameObject, 15f);


    }
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
            Debug.Log("Die");
        }
    }
}
