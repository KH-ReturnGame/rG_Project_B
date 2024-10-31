using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletrigid;
    public Transform player;
    private float speed = 7.5f;
    public Vector3 copiedPlayer;

    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player(Clone)").transform;
        copiedPlayer = player.transform.position;

        Vector2 direction = (copiedPlayer - transform.position).normalized; // �Ѿ� ���ϴ� ���� ���ϱ�

        bulletrigid.AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 3f); // 3�� �� �����
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player" || other.gameObject.tag == "trap") // Ÿ�ϸ��̳� �÷��̾�� �浹�ϸ� �����
        { 
            Destroy(this.gameObject);
        }
    }
}
