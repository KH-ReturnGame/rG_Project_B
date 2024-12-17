using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoom : MonoBehaviour
{
    Enemy enemy;
    public GameObject Boooom;
    bool isboom;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        isboom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.IsContainState(EnemyStates.IsDie) && isboom == false)
        {
            Animator anim = GetComponent<Animator>();
            anim.enabled = false;

            Instantiate(Boooom, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            isboom = true;
        }
    }
}
