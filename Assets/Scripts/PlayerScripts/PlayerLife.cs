using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerLife : MonoBehaviour
    {
        public static event Action PlayerDiedEvent;
        [SerializeField] private List<Image> lifeImages;
        private int _lifeCount;
    
        private void OnEnable()
        {
            _lifeCount = 3;
            EnemyLaserObject.PlayerHit += PlayerGotHit;
        }

        private void OnDisable()
        {
            EnemyLaserObject.PlayerHit -= PlayerGotHit;
        }

        private void PlayerGotHit()
        {
            _lifeCount--;
            Destroy(lifeImages[_lifeCount]);
            if (_lifeCount == 0)
            {
                PlayerDiedEvent?.Invoke();
            }
        }
    }
}
