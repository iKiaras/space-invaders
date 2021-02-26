using UnityEngine;

public class ResultScript : MonoBehaviour
{
   [SerializeField] private GameObject resultScreen;
   private void OnEnable()
   {
      GameManager.GameEndedEvent += ShowResultsScreen;
   }

   private void OnDisable()
   {
      GameManager.GameEndedEvent -= ShowResultsScreen;

   }

   private void ShowResultsScreen()
   {
      resultScreen.SetActive(true);
   }
   
   public void GoToMainMenu()
   {
      SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
   }
}
