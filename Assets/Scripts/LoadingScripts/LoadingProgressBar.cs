using DI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LoadingScripts
{
    public class LoadingProgressBar : MonoBehaviour
    {
        private Image _loadingBar;
        private ILoader _loader;
        private void Awake()
        {
            _loadingBar = GetComponent<Image>();
        }

        private void Update()
        {
            if (!_loader.IsLoadSceneComplete())
            {
                _loadingBar.fillAmount = _loader.GetProgress();
            }
            else
            {
                _loadingBar.fillAmount = SceneLoader.GetLoadingProgress();
            }
        }

        [Inject]
        public void SetLoader(ILoader loader)
        {
            _loader = loader;
        }
    }
}
