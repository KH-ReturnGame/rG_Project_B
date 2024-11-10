using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Transform playerTransform;
    public Transform PortalOut;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("player(Clone)");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector2(PortalOut.position.x, PortalOut.position.y);
        }
    }
}
