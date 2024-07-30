using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : move
{
    Vector2 vec = new Vector2(0, 2);

    // Update is called once per frame
    void Update()
    {
        if (knuck)
        {
            transform.Translate(vec);
        }
    }


}
