using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    Enemy enemy;
    SpriteRenderer spriteRenderer;
    public Sprite _die;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.IsContainState(EnemyStates.IsDie))
        {
            spriteRenderer.sprite = _die;
        }
    }
}
