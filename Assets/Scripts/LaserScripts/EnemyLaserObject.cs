using System;
using UnityEngine;

namespace LaserScripts
{
    public class EnemyLaserObject : MonoBehaviour
    {
        public static event Action PlayerHit;
        
        public static float LaserSpeed = 0.2f;


        private void FixedUpdate()
        {
            transform.position += Vector3.down * LaserSpeed;

            if (transform.position.y <= -6)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                PlayerHit?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        
        }
    }
}