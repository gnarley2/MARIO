using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] Text TimeText;
    [SerializeField] Text CoinText;
    [SerializeField] Text ScoreText;
    [SerializeField] GameObject GameOverText;

    float time = 400;


    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }

        

        if (time > 0)
        {
            time -= Time.deltaTime;
            TimeText.text = time.ToString();
        }
        else
        {
            TimeText.text = "0";
            if (!GameIsPaused)
            {
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
        GameOverText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
