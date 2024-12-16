using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNextTrigger : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneLoadManager.Instance.LoadScene(NextScene);
        }
    }
}
