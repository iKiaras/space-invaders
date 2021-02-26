using PlayerScripts;
using States.PlayerStates;
using UnityEngine;

namespace States
{
    public class PlayState : State
    {
        public PlayState(PlayerController playerController) : base(playerController)
        {
        }


        public override void PlayerMovement(float movement)
        {
            if (_playerController.GetPlayerTransform().position.x < _playerController.GetMinBound() && movement < 0)
            {
                movement = 0;
            }
            else if (_playerController.GetPlayerTransform().position.x > _playerController.GetMaxBound() && movement >0)
            {
                movement = 0;
            }

            _playerController.GetPlayerTransform().position += Vector3.right * (movement * _playerController.GetSpeed());
        }

        
   
        public override void SpawnLaser()
        {
            _playerController.GetLaserController().SpawnLaser(_playerController.GetCanonTransform());
        }
    }
}