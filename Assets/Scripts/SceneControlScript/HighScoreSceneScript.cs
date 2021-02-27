using DI;
using ModestTree;
using TMPro;
using UnityEngine;
using Zenject;

namespace SceneControlScript
{
    public class HighScoreSceneScript : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        private IHighScores _highScores;
    
        void Start()
        {
            highScoreText.text = _highScores.GetHighScores().GetHighScoreList().IsEmpty() ? "No Scores At The Moment!" : _highScores.GetHighScores().ToString();
        }


        [Inject]
        public void SetHighScores(IHighScores highScores)
        {
            _highScores = highScores;
        }
    }
}
