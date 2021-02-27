using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using LaserScripts;
using LoadingScripts;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DI
{
    public class LoaderImpl : ILoader
    {
        private float _progress = 0f;
        private readonly List<Laser> _createdLaserObjectList = new List<Laser>();
        private readonly List<Laser> _createdEnemyLaserObjectList = new List<Laser>();
        private readonly List<NpcScriptableObjects> _createdEnemiesObjectList = new List<NpcScriptableObjects>();
        private GameObject _laserGameObject, _enemyLaserGameObject;
        private readonly List<GameObject> _enemiesList = new List<GameObject>();
    
        private bool _loadLaserComplete = false;
        private bool _loadEnemyLaserComplete = false;
        private bool _loadEnemiesComplete = false;
        private bool _loadSceneComplete = false;

        public async UniTask LoadLaser(AssetReference laserReference)
        {
            await AssetRefLoader.CreateAsset(laserReference, _createdLaserObjectList);
        }

        public async UniTask LoadEnemyLaser(AssetReference enemyLaserReference)
        {
            await AssetRefLoader.CreateAsset(enemyLaserReference, _createdEnemyLaserObjectList);
        }

        public async UniTask LoadEnemies(List<AssetReference> enemiesReference)
        {
            await AssetRefLoader.CreateAssetsAddToList(enemiesReference, _createdEnemiesObjectList);
        }

        

        public void CheckProgress()
        {
            if (_createdLaserObjectList.Count > 0 && !_loadLaserComplete)
            {
                _progress += 0.3f;
                _loadLaserComplete = true;
                _laserGameObject = _createdLaserObjectList[0].LaserModel;
                LaserObject.LaserSpeed = _createdLaserObjectList[0].Speed;
            }
        
            if (_createdEnemyLaserObjectList.Count > 0 && !_loadEnemyLaserComplete)
            {
                _progress += 0.3f;
                _loadEnemyLaserComplete = true;
                _enemyLaserGameObject = _createdEnemyLaserObjectList[0].LaserModel;
                EnemyLaserObject.LaserSpeed = _createdEnemyLaserObjectList[0].Speed;
            }
        
            if (_createdEnemiesObjectList.Count == 3 && !_loadEnemiesComplete)
            {
                _progress += 0.3f;
                _loadEnemiesComplete = true;
                foreach (NpcScriptableObjects enemy in _createdEnemiesObjectList)
                {
                    _enemiesList.Add(enemy.Body);
                }
            }
        
            if (_loadLaserComplete && _loadEnemyLaserComplete && _loadEnemiesComplete && !_loadSceneComplete)
            {
                _progress += 0.3f;
                SceneLoader.LoadMainMenuFirstTime();
                _loadSceneComplete = true;
            }
        }
        
        public bool IsLoadSceneComplete()
        {
            return _loadSceneComplete;
        }
        
        public float GetProgress()
        {
            return _progress;
        }

        public GameObject GetLaserGameObject()
        {
            return _laserGameObject;
        }

        public GameObject GetEnemyLaserGameObject()
        {
            return _enemyLaserGameObject;
        }
        
        public List<GameObject> GetEnemiesList()
        {
            return _enemiesList;
        }
    }
}