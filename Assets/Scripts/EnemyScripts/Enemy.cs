using UnityEngine;

namespace EnemyScripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int row;
        private MeshFilter _meshFilter;
        private bool _meshFilled = false;

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
        }

        private void Update()
        {
            if (!_meshFilled && Loader.Instance.enemiesList.Count > 0)
            {
                _meshFilled = true;
            
                _meshFilter.mesh = Loader.Instance.enemiesList[row].GetComponent<MeshFilter>().sharedMesh;
            }
        }
    }
}
