using LaserScripts;
using States;
using States.PlayerStates;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float minBound, maxBound, fireRate;
        [SerializeField] private Transform canonTransform;
        [SerializeField] private float speed = 0.1f;

        private LaserController _laserController;
        private Transform _player;
        private float _nextFire;
        private State _currentState;

        private void OnEnable()
        {
            GameManager.GameEndedEvent += GameEnded;
        }

        private void OnDisable()
        {
            GameManager.GameEndedEvent -= GameEnded;
        }

        private void Start()
        {
            _currentState = new PlayState(this);
            _player = GetComponent<Transform>();
            _laserController = GetComponent<LaserController>();
        }

        private void FixedUpdate()
        {
            _currentState.PlayerMovement(Input.GetAxis("Horizontal"));
        }

        private void Update()
        {
            if (!Input.GetButton("Fire1") || !(Time.time > _nextFire)) return;
            _nextFire = Time.time + fireRate;
            _currentState.SpawnLaser();
        }

        private void GameEnded()
        {
            _currentState = new PauseState(this);
        }

        public float GetMinBound()
        {
            return minBound;
        }

        public float GetMaxBound()
        {
            return maxBound;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public Transform GetPlayerTransform()
        {
            return _player;
        }

        public Transform GetCanonTransform()
        {
            return canonTransform;
        }

        public LaserController GetLaserController()
        {
            return _laserController;
        }
    }
}
