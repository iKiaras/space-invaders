using System;
using System.Globalization;
using DI;
using EnemyScripts;
using LaserScripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PlayerScripts
{
    public class PlayerScore : MonoBehaviour
    {
        [Header("Game Screen Text")]
        [SerializeField]private Text scoreText, waveText;
        [Header("Result Screen Text")]
        [SerializeField]private Text resultScoreText, resultWaveText;
    
        private int _playerScore;
        private int _enemyWave;
        private IHighScores _highScores;

        private void OnEnable()
        {
            _playerScore = 0;
            _enemyWave = 0;
            LaserObject.EnemyHit += IncreaseScore;
            EnemyController.WaveSpawn += IncreaseWave;
            GameManager.GameEndedEvent += GameEnded;
        }

        private void OnDisable()
        {
            LaserObject.EnemyHit -= IncreaseScore;
            EnemyController.WaveSpawn -= IncreaseWave;
        }

        private void IncreaseWave()
        {
            _enemyWave++;
            waveText.text = "Wave: " + _enemyWave;
        }
    
        private void IncreaseScore()
        {
            _playerScore += 10;
            scoreText.text = "Score: " + _playerScore;
        }
    
        private void GameEnded()
        {
            resultScoreText.text = "Score: " + _playerScore;
            resultWaveText.text = "Wave: " + _enemyWave;
            _highScores.CheckUpdateList(new HighScoreDTO(_playerScore, DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            _enemyWave = 0;
            waveText.text = "Wave: " + _enemyWave;

            _playerScore = 0;
            scoreText.text = "Score: " + _playerScore;
        }
    
        [Inject]    
        public void SetHighScores(IHighScores highScores)
        {
            _highScores = highScores;
        }
    }
    
}
