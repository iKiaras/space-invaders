using System;
using System.Collections.Generic;
using LaserScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerLife : MonoBehaviour
    {
        public static event Action PlayerDiedEvent;
        [SerializeField] private List<Image> lifeImages;
        private int _lifeCount;
        private float _damageImmuneIntervalTime = 0.5f;
        private float _nextDamage;
        private bool _playerDied = false;
    
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
            if (_playerDied) return;
            if (Time.time > _nextDamage)
            {
                _nextDamage += Time.time+_damageImmuneIntervalTime;
                _lifeCount--;
                Destroy(lifeImages[_lifeCount]);
            }
            
            if (_lifeCount == 0)
            {
                _playerDied = true;
                PlayerDiedEvent?.Invoke();
            }
        }
    }
}
