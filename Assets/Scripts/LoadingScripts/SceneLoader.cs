using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        LoadingScene,
        MainMenuScene,
        GameScene
    }

    private static Action _onSceneLoaderCallback;
    private static float _progress = 0;
    
    public static void LoadMainMenuFirstTime()
    {
        SceneManager.LoadScene(Scene.MainMenuScene.ToString());
    }
    
    public static void LoadScene(Scene scene)
    {
        _onSceneLoaderCallback = () => {
            UniTaskLoadScene(scene);
            
            // SceneManager.LoadSceneAsync(scene.ToString());
        };
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    static async UniTask UniTaskLoadScene(Scene scene)
    {
        var  progress = Progress.Create<float>(x => _progress += x);
        await SceneManager.LoadSceneAsync(scene.ToString()).ToUniTask(progress);
    }

    public static void SceneLoaderCallback()
    {
        if (_onSceneLoaderCallback != null)
        {
            _onSceneLoaderCallback();
            _onSceneLoaderCallback = null;
        }
    }

    public static float GetLoadingProgress()
    {
        return _progress;
    } 
}
