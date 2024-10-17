using UnityEngine;

namespace PlayerOwnedStates
{
    public class IsGround  : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class CanJump : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class CanDash : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
           
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDashing : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsWall : State<Player>
    {
        public override void Enter(Player entity)
        {

        }
        public override void Execute(Player entity)
        {
            Debug.Log("WALL");
        }
        public override void Exit(Player entity)
        {
            Debug.Log("WALL EXIT");
        }
    }
    public class IsSlope : State<Player>
    {
        public override void Enter(Player entity)
        {

        }
        public override void Execute(Player entity)
        {

        }
        public override void Exit(Player entity)
        {

        }
    }
    public class IsWallJumping  : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsMove : State<Player>
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDie : State<Player>
    {
        public override void Enter(Player entity)
        {
            Debug.Log("죽었어 ㅜㅜ");
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDragon : State<Player>
    {
        public override void Enter(Player entity)
        {
            Time.timeScale = 0.1f;
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            Time.timeScale = 1;
        }
    }
}

