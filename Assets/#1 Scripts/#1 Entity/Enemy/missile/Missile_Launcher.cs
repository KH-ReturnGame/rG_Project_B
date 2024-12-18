using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Launcher : MonoBehaviour
{
    Enemy enemy;
    SpriteRenderer _flip;
    Animator anim;
    public GameObject missile_perfab;
    public float cool;
    public Vector3 summon_pos;
    public bool isGT;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        _flip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        if(!enemy.IsContainState(EnemyStates.IsDie))
        {
            anim.SetTrigger("attack");
            enemy.AddState(EnemyStates.IsAttacking);
            Vector3 direc = isFlip();
            Quaternion _rotation = Rotate();

            // 미사일 인스턴스 생성
            GameObject missile = Instantiate(missile_perfab, direc, _rotation);

            if (isGT)
            {
                Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(cool);

            StartCoroutine(Fire());
        }
        yield return null;
    }

    Vector3 isFlip()
    {
        if(_flip.flipX != true || isGT)
        {
            return transform.position + summon_pos;
        }
        else
        {
            return transform.position - summon_pos;
        }
    }

    Quaternion Rotate()
    {
        if(isGT)
        {
            return Quaternion.Euler(0, 0, 0);
        }
        else
        {
            if(_flip)
            {
                return Quaternion.Euler(0, 0, 90);
            }
            else
            {
                return Quaternion.Euler(0, 0, 270);
            }
        }
    }
}