using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public GameObject _EscMenu;
    public GameObject _Setting;
    public bool IsMenu;
    // Start is called before the first frame update
    void Start()
    {   
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        IsMenu = false; // 나중에 없어도 되...려나?
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            IsMenu = !IsMenu;
            if(IsMenu)
            {
                _EscMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _EscMenu.SetActive(false);
                _Setting.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
