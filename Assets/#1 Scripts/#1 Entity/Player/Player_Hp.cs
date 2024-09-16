using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Hp : MonoBehaviour
{
    Player _player;
    Image _PlayerHpUI;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _PlayerHpUI = GameObject.Find("Player_HP_UI").GetComponent<Image>();
        _PlayerHpUI.fillAmount = 1;
        StartCoroutine(DecreaseHPOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        _PlayerHpUI.fillAmount = _player._currentHp / _player._maxHp;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trap"))
        {
            _player.TakeDamage(2.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("trap"))
        {
            _player.TakeDamage(2.5f);
        }
    }
}
