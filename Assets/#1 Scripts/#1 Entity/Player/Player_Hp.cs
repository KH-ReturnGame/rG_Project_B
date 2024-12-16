using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Hp : MonoBehaviour
{
    Player _player;  // 플레이어 정보를 저장할 변수
    Image _PlayerHpUI;  // 체력 UI를 저장할 변수

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();  // Player 컴포넌트를 가져옴
        _PlayerHpUI = GameObject.Find("Player_HP_UI").GetComponent<Image>();  // "Player_HP_UI"라는 이름의 UI 오브젝트를 찾고 Image 컴포넌트를 가져옴
        _PlayerHpUI.fillAmount = 1;  // 체력 UI의 fillAmount를 1로 설정 (체력이 가득 찬 상태로 설정)
        StartCoroutine(DecreaseHPOverTime());  // 체력이 서서히 감소하는 코루틴을 시작
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 현재 체력에 따라 UI 체력 바의 fillAmount를 실시간으로 업데이트
        _PlayerHpUI.fillAmount = _player._currentHp / _player._maxHp;
    }

    // 체력이 시간이 지남에 따라 감소하는 코루틴
    IEnumerator DecreaseHPOverTime()
    {
        while(true)
        {
            // 매 프레임마다 0.25의 체력 감소
            _player.TakeDamage(0.25f);
            yield return null;  // 한 프레임을 기다림
            yield return new WaitForSeconds(0.02f);  // 0.02초 대기
        }
    }

    // 2D 충돌 시 호출되는 메서드
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "trap" 태그를 가질 경우
        if(collision.gameObject.CompareTag("trap"))
        {
            // 체력 감소
            _player.TakeDamage(2.5f);
            // "IsWall"과 "IsDragon" 상태를 제거
            _player.RemoveState(PlayerStates.IsWall);
            _player.RemoveState(PlayerStates.IsDragon);
        }
    }

    // 2D 트리거 충돌 시 호출되는 메서드
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 "trap" 태그를 가질 경우
        if(other.gameObject.CompareTag("trap"))
        {
            // 체력 감소
            _player.TakeDamage(2.5f);
            // "IsWall"과 "IsDragon" 상태를 제거
            _player.RemoveState(PlayerStates.IsWall);
            _player.RemoveState(PlayerStates.IsDragon);
        }
    }
}
