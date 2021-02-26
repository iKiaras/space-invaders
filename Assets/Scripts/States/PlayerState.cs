
using PlayerScripts;

namespace States
{
    public abstract class State
    {
        protected readonly PlayerController _playerController;
   
        protected State(PlayerController playerController)
        {
            _playerController = playerController;
        }
   
        public  virtual void PlayerMovement(float movement)
        {
        }
   
   
        public  virtual void SpawnLaser()
        {
        }
   
   
    }
}
