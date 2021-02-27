using ModestTree;
using PlayerScripts;
using UnityEngine;

namespace DI
{
    public class HighScoresImpl : IHighScores
    {
        private static readonly string HighscoreKey = "HighScores";
        private HighScoreList _highScoreList;

        public void LoadHighScores()
        {
            _highScoreList = (HighScoreList) JsonUtility.FromJson(PlayerPrefs.GetString(HighscoreKey), (typeof(HighScoreList)));
            if (_highScoreList == null)
            {
                _highScoreList = new HighScoreList();
            }
        }

        public HighScoreList GetHighScores()
        {
            return _highScoreList;
        }

        public void CheckUpdateList(HighScoreDTO newScore)
        {
            if (_highScoreList.GetHighScoreList().IsEmpty())
            {
                _highScoreList.GetHighScoreList().Add(newScore);
            }
            else
            {
                _highScoreList.GetHighScoreList().Sort((a, b) => a.GetScore().CompareTo(b.GetScore()));

                if (_highScoreList.GetHighScoreList().Count > 10)
                {
                    _highScoreList.GetHighScoreList().RemoveRange(10, _highScoreList.GetHighScoreList().Count-1);
                }
            
                SaveHighScores();
            }
            
        }
        
        private void SaveHighScores()
        {
            PlayerPrefs.SetString(HighscoreKey,JsonUtility.ToJson(_highScoreList));
            PlayerPrefs.Save();
        }
        
    }
}