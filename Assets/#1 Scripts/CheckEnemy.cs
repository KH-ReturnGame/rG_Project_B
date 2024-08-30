using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    public List<GameObject> Dash_Enemy = new List<GameObject>();
    public bool IsChecked;
   	 private void Start()
   	 {
   	     target = transform.parent.position;
         IsChecked = false;
   	 }
   	 private void Update()
   	 {
   	     mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   	     angle = Mathf.Atan2(mouse.y - target.y+1.4f, mouse.x - target.x) * Mathf.Rad2Deg;
   	     this.transform.parent.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
         if (Input.GetMouseButtonDown(0))
        {
            if (IsChecked)
            {
// 리스트에 있는 모든 적에게 데미지를 줌
                for (int i = 0; i < Dash_Enemy.Count; i++)
                {
                // 각 적 오브젝트의 Enemy 컴포넌트를 가져옴
                 Enemy enemy = Dash_Enemy[i].GetComponent<Enemy>();
        
                // 해당 Enemy가 존재한다면 (null 체크)
                    if (enemy != null)
                {
                // 데미지를 가함
                    enemy.TakeDamage(1);
                }
                else
                {
                    IsChecked = false;
                }
    }
}
            // for문으로 ischecked상태 수정하기, chat gpt에 Dash_Enemy에 아예 오브젝트가 없을 때 IsChecked를 false로 바꿔야됨

        }

  	  }
     private void OnTriggerEnter2D(Collider2D other)
     {
        List<GameObject> List_Enemy = new List<GameObject.other>();
        if(other.gameObject.tag == "Enemy");
        {
            GameObject _enemy = List_Enemy.Find(obj => obj.tag == "Enemy");
            Dash_Enemy.Add(_enemy);
            IsChecked = true;
        }
     }
     private void OnTriggerExit2D(Collider2D other)
     {
        if(other.gameObject.tag == "Enemy");
        {
            GameObject _enemy = List_Enemy.Find(obj => obj.tag == "Enemy");
            Dash_Enemy.Remove(_enemy);
            IsChecked = false;
        }
     }
}
