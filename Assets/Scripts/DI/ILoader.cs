using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DI
{
    public interface ILoader
    {
        UniTask LoadLaser(AssetReference laserReference);

        UniTask LoadEnemyLaser(AssetReference enemyLaserReference);

        UniTask LoadEnemies(List<AssetReference> enemiesReference);

        void CheckProgress();
        
        bool IsLoadSceneComplete();
        
        float GetProgress();

        GameObject GetLaserGameObject();

        GameObject GetEnemyLaserGameObject();
        
        List<GameObject> GetEnemiesList();
    }
}