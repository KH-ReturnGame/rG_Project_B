using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro를 사용할 경우 필요

public class EndSpeed : MonoBehaviour
{
    public GameObject EndUI;
    public TMP_InputField inputField; // TMP_InputField를 사용할 경우
    rankManager _rankManager;
    float SpeedTime;
    public Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        _rankManager = GetComponent<rankManager>();
        SpeedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedTime += Time.deltaTime;
        UpdateTimerUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            EndUI.SetActive(true);
        }
    }

    public void OnSubmit()
    {
        string userInput = inputField.text;
        _rankManager.SetRank(3, userInput, uiText.text, false);
        SceneLoadManager.Instance.LoadScene("StartScene");
    }

    private void UpdateTimerUI()
    {
        uiText.text = string.Format("{0:F5}", SpeedTime);
    }
}
