using System;
using UnityEngine;

public class LaserObject : MonoBehaviour
{
    public static event Action EnemyHit;
    private float _nextDamage;
    public static float LaserSpeed = 0.2f;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * LaserSpeed;

            if (transform.position.y >= 10)
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Enemy")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
        EnemyHit?.Invoke();
    }

}