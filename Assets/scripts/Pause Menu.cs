using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // "Pause Menu" sahnesi yüklüyse onu kapat ve oyunu devam ettir
        if (SceneManager.GetSceneByName("Pause Menu").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Pause Menu");
            Time.timeScale = 1f;  // Oyunu devam ettir
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Oyun durdurulmuþsa durumu sýfýrla
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ResetPauseState();
            }
        }
        else
        {
            // Eðer "Pause Menu" sahnesi yüklü deðilse normal oyun sahnesini yükle
            SceneManager.LoadSceneAsync("SpaceJump");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
