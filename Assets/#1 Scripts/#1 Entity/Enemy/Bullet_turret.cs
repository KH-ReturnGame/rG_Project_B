using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_turret : MonoBehaviour
{
    private Rigidbody2D bulletrigid;
    private float speed = 10f;
    [SerializeField]
    public int fire_direc;

    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(fire_direc, 0).normalized;

        bulletrigid.AddForce(direction * speed, ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player" || other.gameObject.tag == "trap")
        { 
            Destroy(this.gameObject);
        }
    }
}
