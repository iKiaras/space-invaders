using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Loader : MonoBehaviour
{
    public static Loader Instance { get { return _instance; } }
    private static Loader _instance;

    [SerializeField] private AssetReference laserReference, enemyLaserReference;
    [SerializeField] private List<AssetReference> enemiesReference;
    
    [HideInInspector]
    public GameObject laserGameObject, enemyLaserGameObject;
    [HideInInspector]
    public List<GameObject> enemiesList = new List<GameObject>();
    
    private readonly List<Laser> _createdLaserObjectList = new List<Laser>();
    private readonly List<Laser> _createdEnemyLaserObjectList = new List<Laser>();
    private readonly List<NpcScriptableObjects> _createdEnemiesObjectList = new List<NpcScriptableObjects>();

    private float _progress = 0f;
    private bool _loadLaserComplete = false;
    private bool _loadEnemyLaserComplete = false;
    private bool _loadEnemiesComplete = false;
    private bool _loadSceneComplete = false;


    private void Awake()
    {
            LoadLaser();
            LoadEnemyLaser();
            LoadEnemies();

            DontDestroyOnLoad(_instance);
    }

    // Update is called once per frame
    void Update()
    {
        if (_createdLaserObjectList.Count > 0 && !_loadLaserComplete)
        {
            _progress += 0.3f;
            _loadLaserComplete = true;
            laserGameObject = _createdLaserObjectList[0].LaserModel;
            LaserObject.LaserSpeed = _createdLaserObjectList[0].Speed;
        }
        
        if (_createdEnemyLaserObjectList.Count > 0 && !_loadEnemyLaserComplete)
        {
            _progress += 0.3f;
            _loadEnemyLaserComplete = true;
            enemyLaserGameObject = _createdEnemyLaserObjectList[0].LaserModel;
            EnemyLaserObject.LaserSpeed = _createdEnemyLaserObjectList[0].Speed;
        }

        if (_createdEnemiesObjectList.Count == 3 && !_loadEnemiesComplete)
        {
            _progress += 0.3f;
            _loadEnemiesComplete = true;
            foreach (NpcScriptableObjects enemy in _createdEnemiesObjectList)
            {
                enemiesList.Add(enemy.Body);
            }
        }

        if (_loadLaserComplete && _loadEnemyLaserComplete && _loadEnemiesComplete && !_loadSceneComplete)
        {
            _progress += 0.3f;
            SceneLoader.LoadMainMenuFirstTime();
            _loadSceneComplete = true;
        }
    }

    public float GetLoadingProgress()
    {
        return _progress;
    }

    private async UniTask LoadLaser()
    {
        await AssetRefLoader.CreateAsset(laserReference, _createdLaserObjectList);
    }

    private async UniTask LoadEnemyLaser()
    {
        await AssetRefLoader.CreateAsset(enemyLaserReference, _createdEnemyLaserObjectList);
    }

    private async UniTask LoadEnemies()
    {
        await AssetRefLoader.CreateAssetsAddToList(enemiesReference, _createdEnemiesObjectList);
    }
    
    public bool IsloadSceneComplete()
    {
        return _loadSceneComplete;
    }
}
