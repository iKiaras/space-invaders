using UnityEngine;

public class SceneLoaderCallback : MonoBehaviour
{
    private bool _isFirstUpdate = true;

    // Update is called once per frame
    void Update()
    {
        if (_isFirstUpdate)
        {
            _isFirstUpdate = false;
            SceneLoader.SceneLoaderCallback();
        }
    }
}
