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
        if (pauseMenuUI.GetComponent<Canvas>().worldCamera == null)
        {
            pauseMenuUI.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
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
        if (retryMenuUI.GetComponent<Canvas>().worldCamera == null)
        {
            retryMenuUI.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        int id = SceneManager.GetActiveScene().buildIndex + 1;
        if (id >= SceneManager.sceneCountInBuildSettings)
        {
            GoToMainMenu();
            return;
        }

        SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene newScene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SceneLoaded;

        SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"), newScene);

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
