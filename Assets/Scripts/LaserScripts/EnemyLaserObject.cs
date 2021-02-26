using System;
using UnityEngine;

public class EnemyLaserObject : MonoBehaviour
{
    public static event Action PlayerHit;
    private float _damageImmuneIntervalTime = 3f;
    private float _nextDamage;
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
        if ((Time.time > _nextDamage) && other.tag.Equals("Player"))
        {
            _nextDamage += _damageImmuneIntervalTime;
            PlayerHit?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}