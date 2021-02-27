using System.Collections.Generic;
using DI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace LoadingScripts
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private AssetReference laserReference, enemyLaserReference;
        [SerializeField] private List<AssetReference> enemiesReference;

        private  ILoader _iLoader;
    
        private void Awake()
        {
            _iLoader.LoadLaser(laserReference);
            _iLoader.LoadEnemyLaser(enemyLaserReference);
            _iLoader.LoadEnemies(enemiesReference);
        }
    
        void Update()
        {
            _iLoader.CheckProgress();
        
        }

        [Inject]
        public void SetILoader(ILoader iLoader)
        {
            _iLoader = iLoader;
        }
    }
}
