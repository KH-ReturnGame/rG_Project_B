using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckback : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Debug.Log("³Ë¹é!");
        }
    }
}
