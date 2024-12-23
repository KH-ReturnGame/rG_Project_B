using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject StartCam;
    public GameObject UI;
    float a = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCor());
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        StartCam.transform.position = new Vector3(0, a/2.5f, -10);
    }

    IEnumerator startCor()
    {
        UI.SetActive(false);

        yield return new WaitForSeconds(5f);//딱 [5초]...다!
        
        SceneLoadManager.Instance.LoadScene("main");

        yield return null;
    }
}
