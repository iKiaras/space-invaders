
using System;
using UnityEngine;

namespace PlayerScripts
{
    [Serializable]
    public class HighScoreDTO
    {
        [SerializeField]
        private int _score;
        [SerializeField]
        private string _date;
        
        public HighScoreDTO()
        {
        }
        
        public HighScoreDTO(int score, string date)
        {
            _score = score;
            _date = date;
        }

        public int GetScore()
        {
            return _score;
        }

        public string GetDate()
        {
            return _date;
        }
    }
}
