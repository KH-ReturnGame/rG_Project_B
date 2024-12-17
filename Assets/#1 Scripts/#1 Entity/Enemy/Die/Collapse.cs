using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ForceToCollapse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForceToCollapse()
    {
        rigid.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        rigid.AddForce(transform.right * 0.5f, ForceMode2D.Impulse);
    }
}
