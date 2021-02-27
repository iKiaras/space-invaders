using ModestTree;
using PlayerScripts;
using UnityEngine;

namespace DI
{
    public class HighScoresImpl : IHighScores
    {
        private static readonly string HighscoreKey = "HighScores";
        private HighScoreList _highScoreList;

        

        public HighScoreList GetHighScores()
        {
            if (_highScoreList == null)
            {
                LoadHighScores();
            }
            return _highScoreList;
        }
        
        private void LoadHighScores()
        {
            _highScoreList = (HighScoreList) JsonUtility.FromJson(PlayerPrefs.GetString(HighscoreKey), (typeof(HighScoreList)));
            if (_highScoreList == null)
            {
                _highScoreList = new HighScoreList();
            }
        }

        public void CheckUpdateList(HighScoreDTO newScore)
        {
            if (_highScoreList.GetHighScoreList().IsEmpty())
            {
                _highScoreList.GetHighScoreList().Add(newScore);
            }
            else
            {
                _highScoreList.GetHighScoreList().Add(newScore);
                _highScoreList.GetHighScoreList().Sort((a, b) => b.GetScore().CompareTo(a.GetScore()));

                if (_highScoreList.GetHighScoreList().Count > 10)
                {
                    _highScoreList.GetHighScoreList().RemoveAt(10);
                }
            
                
            }
            SaveHighScores();
        }

        private void SaveHighScores()
        {
            PlayerPrefs.SetString(HighscoreKey,JsonUtility.ToJson(_highScoreList));
            PlayerPrefs.Save();
        }
        
    }
}