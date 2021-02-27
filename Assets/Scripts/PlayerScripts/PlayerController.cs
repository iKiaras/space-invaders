using System;
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

        public Transform circle;
        public Transform outerCircle;
        public GameObject fireButton;
        private Vector2 startingPoint;
        private int leftTouch = 99;
        
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
            #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
                fireButton.gameObject.SetActive(false);
                circle.gameObject.SetActive(false);
                outerCircle.gameObject.SetActive(false);
            #endif
            _currentState = new PlayState(this);
            _player = GetComponent<Transform>();
            _laserController = GetComponent<LaserController>();
        }

        private void FixedUpdate()
        {
            #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
            _currentState.PlayerMovement(Input.GetAxis("Horizontal"));
            #else
            
            int i = 0;
            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
                if (t.phase == TouchPhase.Began)
                {
                    if (Math.Abs(touchPos.x - fireButton.transform.position.x) < 0.5 && Math.Abs(touchPos.y - fireButton.transform.position.y) < 0.5)
                    {
                        FireLaser();
                    }
                    else
                    {
                        leftTouch = t.fingerId;
                        startingPoint = touchPos;
                    }
                }
                else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
                {
                    Vector2 offset = touchPos - startingPoint;
                    Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
                    
                    if (direction.x > 0)
                    {
                        _currentState.PlayerMovement(1f);
                    } else if (direction.x < 0)
                    {
                        _currentState.PlayerMovement(-1f);
                    }

                    circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x,
                        outerCircle.transform.position.y);

                }
                else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
                {
                    leftTouch = 99;
                    circle.transform.position =
                        new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
                }

                ++i;
            }
            #endif

        }
        
        Vector2 getTouchPosition(Vector2 touchPosition){
            return FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }

        private void Update()
        {
        #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
            if (Input.GetButton("Fire1"))
                FireLaser();
        #endif
        }
        public void FireLaser()
        {
            if (!(Time.time > _nextFire)) return;
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