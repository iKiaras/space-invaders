using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Transform _laserTransform;
    private float _damageImmuneIntervalTime = 3f;
    private float _nextDamage;
    private bool _isEnemy;


    public void SpawnLaser(Transform spawnPosition)
    {
        Instantiate(Loader.Instance.laserGameObject, spawnPosition.position, spawnPosition.rotation);
    }

    public void SpawnEnemyLaser(Transform spawnPosition)
    {
        Vector3 position = new Vector3(spawnPosition.position.x, spawnPosition.position.y - 1, spawnPosition.position.z);
        Instantiate(Loader.Instance.enemyLaserGameObject, position, spawnPosition.rotation);
    }
}
