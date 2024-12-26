using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Bye", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Bye()
    {
        Destroy(gameObject);
    }
}
