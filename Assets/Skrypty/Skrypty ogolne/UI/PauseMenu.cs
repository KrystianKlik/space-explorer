using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject time;
    public GameObject helpText;
    


    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}

    // Update is called once per frame
    void Update () {
       
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Resume();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !helpText.activeSelf)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

	}

   public void Resume()
    {
        time.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   public void Pause()
    {
        time.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reset(int numerPoziomu)
    {
        if (numerPoziomu == 1)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("SpaceX");
#pragma warning restore CS0618 // Type or member is obsolete

        }

        else if (numerPoziomu == 2)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Ksiezyc");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );

        else if(numerPoziomu == 3)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Awaria");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Wyszlismy");
        Application.Quit();

    }

    public void HelpMenu()
    {
        time.SetActive(false);
        helpText.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    
}
