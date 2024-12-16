using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Launcher : MonoBehaviour
{
    public GameObject missile_perfab;
    public float cool;
    public Vector3 summon_pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        Instantiate(missile_perfab, summon_pos, transform.rotation);
        
        yield return new WaitForSeconds(cool);

        StartCoroutine(Fire());
    }
}
