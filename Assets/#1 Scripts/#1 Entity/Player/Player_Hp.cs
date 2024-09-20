using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Hp : MonoBehaviour
{
    Player _player;
    Image _PlayerHpUI;
    public Button Retry_UI;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _PlayerHpUI = GameObject.Find("Player_HP_UI").GetComponent<Image>();
        _PlayerHpUI.fillAmount = 1;
        StartCoroutine(DecreaseHPOverTime());
        Retry_UI.gameObject.SetActive(false);
        Retry_UI.onClick.AddListener(RetryGame);
            
    }

    // Update is called once per frame
    void Update()
    {
        _PlayerHpUI.fillAmount = _player._currentHp / _player._maxHp;

        if (_PlayerHpUI.fillAmount == 0)
            Retry_UI.gameObject.SetActive(true);
    }

    IEnumerator DecreaseHPOverTime()
    {
        while(true)
        {
            _player.TakeDamage(0.25f);
            yield return null;
            yield return new WaitForSeconds(0.02f);
        }
    }
    
    void RetryGame()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
