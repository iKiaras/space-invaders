using System;
using EnemyScripts;
using PlayerScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action GameEndedEvent;

    //TODO Singleton
    private void OnEnable()
    {
        PlayerLife.PlayerDiedEvent += PlayerDied;
        EnemyController.BaseHit += PlayerDied;
    }

    private void OnDisable()
    {
        PlayerLife.PlayerDiedEvent -= PlayerDied;
        EnemyController.BaseHit -= PlayerDied;
    }
    
    private static void PlayerDied()
    {
        GameEndedEvent?.Invoke();
    }
}
