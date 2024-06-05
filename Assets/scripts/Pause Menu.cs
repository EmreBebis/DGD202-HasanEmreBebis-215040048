using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // "Pause Menu" sahnesi y�kl�yse onu kapat ve oyunu devam ettir
        if (SceneManager.GetSceneByName("Pause Menu").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Pause Menu");
            Time.timeScale = 1f;  // Oyunu devam ettir
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Oyun durdurulmu�sa durumu s�f�rla
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ResetPauseState();
            }
        }
        else
        {
            // E�er "Pause Menu" sahnesi y�kl� de�ilse normal oyun sahnesini y�kle
            SceneManager.LoadSceneAsync("SpaceJump");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
