using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private string pauseMenuSceneName = "Pause Menu";  // Pause Menu sahnesinin ad�

    void Update()
    {
        // 'p' tu�una bas�ld���nda oyunu durdur ve pause men�s�ne ge�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        // E�er "Pause Menu" sahnesi zaten y�kl�yse i�lemi yapma
        if (SceneManager.GetSceneByName(pauseMenuSceneName).isLoaded) return;

        // Oyunu durdur
        Time.timeScale = 0f;
        isPaused = true;
        // Pause Menu sahnesine ge�
        SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
        // Fare imlecini etkinle�tir ve kilidini a�
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        // E�er "Pause Menu" sahnesi y�kl� de�ilse i�lemi yapma
        if (!SceneManager.GetSceneByName(pauseMenuSceneName).isLoaded) return;

        // Pause Menu sahnesini kapat
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
        // Oyunu yeniden ba�lat
        Time.timeScale = 1f;
        isPaused = false;
        // Fare imlecini devre d��� b�rak ve kilitle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResetPauseState()
    {
        isPaused = false;
    }
}
