using DI;
using UnityEngine;
using Zenject;

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
            // if (!_meshFilled && _iLoader.GetEnemiesList().Count > 0)
            // {
            //     _meshFilled = true;
            //
            //     _meshFilter.mesh = _iLoader.GetEnemiesList()[row].GetComponent<MeshFilter>().sharedMesh;
            // }
        }

        public int GetRow()
        {
            return row;
        }
        
    }
}
