using DI;
using UnityEngine;
using Zenject;

namespace LaserScripts
{
    public class LaserController : MonoBehaviour
    {
        private Transform _laserTransform;
        private float _damageImmuneIntervalTime = 3f;
        private float _nextDamage;
        private bool _isEnemy;
        private ILoader _loader;

        public void SpawnLaser(Transform spawnPosition)
        {
            Instantiate(_loader.GetLaserGameObject(), spawnPosition.position, spawnPosition.rotation);
        }

        public void SpawnEnemyLaser(Transform spawnPosition)
        {
            Vector3 position = new Vector3(spawnPosition.position.x, spawnPosition.position.y - 1, spawnPosition.position.z);
            Instantiate(_loader.GetEnemyLaserGameObject(), position, spawnPosition.rotation);
        }

        [Inject]
        public void SetLoader(ILoader loader)
        {
            _loader = loader;
        }
    }
}
