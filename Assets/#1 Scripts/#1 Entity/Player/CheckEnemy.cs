using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    [SerializeField] private List<GameObject> enemiesInRange = new List<GameObject>();  
    // 범위 내 에너미 리스트
   	void Start()
   	{
   	    target = transform.parent.position;
   	}
   	void Update()
   	{
   	    mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   	    angle = Mathf.Atan2(mouse.y - target.y+3.1f, mouse.x - target.x+0.7f) * Mathf.Rad2Deg;
   	    this.transform.parent.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        if (Input.GetMouseButtonDown(0) && enemiesInRange.Count > 0)
        {
            // 리스트에 있는 모든 적에게 데미지를 줌
            foreach (GameObject _enemyobj in enemiesInRange)
            {
                // 각 적 오브젝트의 Enemy 컴포넌트를 가져옴
                Enemy enemy = _enemyobj.GetComponent<Enemy>();
                // 데미지를 가함
                enemy.TakeDamage(1);
                if(enemy == null)
                {
                    Debug.Log("null임 ㅅㄱ");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Enemy"))
        {
            if (!enemiesInRange.Contains(other.gameObject))
            {
                enemiesInRange.Add(other.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Enemy"))
        {
            if (enemiesInRange.Contains(other.gameObject))
            {
                enemiesInRange.Remove(other.gameObject);
            }
        }
    }
}