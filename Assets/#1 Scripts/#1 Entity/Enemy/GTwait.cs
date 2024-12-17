using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTwait : MonoBehaviour
{
    missile _missile;
    // Start is called before the first frame update
    void Start()
    {
        _missile = GetComponent<missile>();
        Invoke("missileOn", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void missileOn()
    {
        _missile.enabled = true;
    }
}
