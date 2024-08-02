using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    public Vector2 vec = new Vector2(0, 2);
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        transform.position = player.GetComponent<Transform>().position;
    }

}
