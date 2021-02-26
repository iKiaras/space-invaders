using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Image _loadingBar;

    private void Awake()
    {
        _loadingBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (!Loader.Instance.IsloadSceneComplete())
        {
            _loadingBar.fillAmount = Loader.Instance.GetLoadingProgress();
        }
        else
        {
            _loadingBar.fillAmount = SceneLoader.GetLoadingProgress();
        }
    }
}
