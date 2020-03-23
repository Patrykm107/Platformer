using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject retryMenuUI;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        retryMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadNextLevel()
    {
        int id = SceneManager.GetActiveScene().buildIndex + 1;
        if (id < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(id);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
