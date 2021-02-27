using DI;
using TMPro;
using UnityEngine;
using Zenject;

namespace SceneControlScript
{
    public class HighScoreScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        private IHighScores _highScores;
    
        void Start()
        {
            if (_highScores.GetHighScores() == null)
            {
                highScoreText.text = "No Scores At The Moment!";
            }
            else
            {
                highScoreText.text = _highScores.GetHighScores().ToString();
            }
        }


        [Inject]
        public void SetHighScores(IHighScores highScores)
        {
            _highScores = highScores;
        }
    }
}
