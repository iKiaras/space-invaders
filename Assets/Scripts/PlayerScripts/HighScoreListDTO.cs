using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    [Serializable]
    public class HighScoreList
    {
        [SerializeField]
        private List<HighScoreDTO> _scores = new List<HighScoreDTO>();

        public HighScoreList()
        {
        }

        public List<HighScoreDTO> GetHighScoreList()
        {
            return _scores;
        }

        public override string ToString()
        {
            string toString = "";

            foreach (HighScoreDTO highScore in _scores)
            {
                toString += highScore.GetScore() + " - " + highScore.GetDate() + "\n";
            }

            return toString;
        }
    }
}
