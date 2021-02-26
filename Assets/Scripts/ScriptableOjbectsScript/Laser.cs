using UnityEngine;

    [CreateAssetMenu(fileName = "Laser", menuName = "Laser")]
    public class Laser : ScriptableObject
    {
        [SerializeField ]private GameObject _laserModel;
        [SerializeField] private float _speed = 0.1f;

        public GameObject LaserModel => _laserModel;
        public float Speed => _speed;

    }

