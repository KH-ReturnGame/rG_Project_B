using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapCheck : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite Ouch;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = Ouch;
        }
    }
}