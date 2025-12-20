using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public void PlayGame(int sceneNumber)
   {
      SceneManager.LoadSceneAsync(sceneNumber);
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
