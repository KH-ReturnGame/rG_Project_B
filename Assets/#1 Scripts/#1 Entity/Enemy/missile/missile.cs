using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    bool alive = true;
    float dashspeed = 7.5f;
    GameObject player;
    float angle;
    public float speed;
    Rigidbody2D target;
    Rigidbody2D rigid;

    void Start()
    {
        player = GameObject.Find("player(Clone)");
        target = player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(lifetime());
    }

    //do while alive
    IEnumerator lifetime()
    {
        yield return new WaitForSeconds(3f);               //operate after 3s
        alive = false;                                    //stop chasing
        Vector2 direction = (player.transform.position - transform.position).normalized;  //make direction
        rigid.AddForce(direction * dashspeed, ForceMode2D.Impulse);                       //add force
        Destroy(this,5);                                                                  //destroy after 5s
    }

    void FixedUpdate()
    {
        if (alive)
        {
            movement();
        }
    }

    //move while alive
    void movement()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                            player.transform.position.x - transform.position.x)
              * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
        }
    }
}