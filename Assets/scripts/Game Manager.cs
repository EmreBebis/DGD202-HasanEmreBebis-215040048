using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private string pauseMenuSceneName = "Pause Menu";  // Pause Menu sahnesinin adý

    void Update()
    {
        // 'p' tuþuna basýldýðýnda oyunu durdur ve pause menüsüne geç
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
        // Eðer "Pause Menu" sahnesi zaten yüklüyse iþlemi yapma
        if (SceneManager.GetSceneByName(pauseMenuSceneName).isLoaded) return;

        // Oyunu durdur
        Time.timeScale = 0f;
        isPaused = true;
        // Pause Menu sahnesine geç
        SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
        // Fare imlecini etkinleþtir ve kilidini aç
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        // Eðer "Pause Menu" sahnesi yüklü deðilse iþlemi yapma
        if (!SceneManager.GetSceneByName(pauseMenuSceneName).isLoaded) return;

        // Pause Menu sahnesini kapat
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
        // Oyunu yeniden baþlat
        Time.timeScale = 1f;
        isPaused = false;
        // Fare imlecini devre dýþý býrak ve kilitle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResetPauseState()
    {
        isPaused = false;
    }
}
