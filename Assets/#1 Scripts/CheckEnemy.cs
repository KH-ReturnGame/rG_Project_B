using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    public List<GameObject> Dash_Enemy = new List<GameObject>();
    
   	 private void Start()
   	 {
   	     target = transform.position;
   	 }
   	 private void Update()
   	 {
   	     mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   	     angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
   	     this.transform.parent.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
  	  }
     private void OnTriggerEnter2D(Collider2D other)
     {
        if(other.gameObject.tag == "Enemy");
        {
            Dash_Enemy.Add(other.gameObject);
        }
     }
     private void OnTriggerExit2D(Collider2D other)
     {
        if(other.gameObject.tag == "Enemy");
        {
            Dash_Enemy.Remove(other.gameObject);
        }
     }
}
