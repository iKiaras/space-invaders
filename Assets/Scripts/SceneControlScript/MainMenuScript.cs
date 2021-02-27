using System;
using LoadingScripts;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuScript : MonoBehaviour
{
   [SerializeField] private UnityEvent onChangeHighScoreScene;
   [SerializeField] private UnityEvent onChangeMainMenuScene;
   [SerializeField] private GameObject highScoreField;
   

   public void ChangeToGameScene()
   {
      SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
   }

   public void ChangeToHighScoreScene()
   {
      onChangeHighScoreScene?.Invoke();
   }

   public void ChangeToMainMenuScene()
   {
      onChangeMainMenuScene?.Invoke();
   }
}
