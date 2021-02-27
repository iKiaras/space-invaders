
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class HighScoreList
    {
        [SerializeField]
        private List<HighScoreDTO> _scores;

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
                toString += highScore.GetScore() + " - " + highScore.GetDate() + "/n";
            }

            return toString;
        }
    }
}
