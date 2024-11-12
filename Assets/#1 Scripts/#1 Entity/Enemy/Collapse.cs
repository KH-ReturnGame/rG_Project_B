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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ForceToCollapse()
    {
        // 대쉬에서 태그가 collapse일때 실행되어 타격감을 높임
        // rigid 나 벡터로 힘을 주기(많이는 말고, 스컬처럼)
    }
}
