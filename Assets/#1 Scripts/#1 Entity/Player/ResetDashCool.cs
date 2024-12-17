using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDashCool : MonoBehaviour
{
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ground")) 
        {
            _player.AddState(PlayerStates.CanDash);
        }
    }
}
