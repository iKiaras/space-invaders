using System;
using LaserScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject enemiesPrefab;
        private Transform _enemyHolder;
        private LaserController _laserController;
        private float _movementSpeed = 0.3f;
        private const float RepeatRate = .6f;
        public static event Action BaseHit;
        public static event Action WaveSpawn;
        private Vector3 _position;

        private void OnEnable()
        {
            GameManager.GameEndedEvent += GameEnded;
        }

        private void OnDisable()
        {
            GameManager.GameEndedEvent -= GameEnded;
        }

        void Start()
        {
            _enemyHolder = GetComponent<Transform>();
            _position = _enemyHolder.position;
            _laserController = GetComponent<LaserController>();
            InvokeRepeating(nameof(MoveEnemy),0.1f,RepeatRate);
        }
    
        private void MoveEnemy()
        {
            _enemyHolder.position += Vector3.right * _movementSpeed;

            foreach (Transform enemy in _enemyHolder) {
                if (enemy.position.x < -2.4 || enemy.position.x > 2.0) {
                    _movementSpeed = -_movementSpeed;
                    _enemyHolder.position += Vector3.down * 0.3f;
                    return;
                }

                if (Random.value > 0.976f) {
                    _laserController.SpawnEnemyLaser(enemy);
                }
            
                if (enemy.position.y <= -4) {
                    BaseHit?.Invoke();
                    Time.timeScale = 0;
                }
            }

            if (_enemyHolder.childCount == 1) {
                CancelInvoke ();
                InvokeRepeating ("MoveEnemy", 0.1f, RepeatRate - 3f);
            }

            if (_enemyHolder.childCount == 0)
            {
                WaveSpawn?.Invoke();
                GameObject enemiesList = Instantiate(enemiesPrefab, _position, _enemyHolder.rotation);
                _enemyHolder.position = _position;
                foreach (Transform enemy in enemiesList.GetComponentsInChildren<Transform>())
                {
                    enemy.parent = _enemyHolder;
                }
                Destroy(enemiesList);
            }
        }

        public void SetMoveSpeed(float newMoveSpeed)
        {
            _movementSpeed = newMoveSpeed;
        }
    
        public float GetMoveSpeed()
        {
            return _movementSpeed;
        }
    
        public Transform GetEnemyHolder()
        {
            return _enemyHolder;
        }

        private void GameEnded()
        {
            CancelInvoke();
        }
    }
}
