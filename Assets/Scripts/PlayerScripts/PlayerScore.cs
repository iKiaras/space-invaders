using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerScore : MonoBehaviour
    {
        [Header("Game Screen Text")]
        [SerializeField]private Text scoreText, waveText;
        [Header("Result Screen Text")]
        [SerializeField]private Text resultScoreText, resultWaveText;
    
        private float _playerScore;
        private int _enemyWave;

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
        
            _enemyWave = 0;
            waveText.text = "Wave: " + _enemyWave;

            _playerScore = 0;
            scoreText.text = "Score: " + _playerScore;
        }
    
    }
}
