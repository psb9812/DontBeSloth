using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string mainMenuScene = "title";
    public GameObject pauseMenu;
    bool nowMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        nowMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        //R키를 누르면 다시시작.
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!nowMenu)
            {
                pauseMenu.SetActive(true);
                nowMenu = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                nowMenu = false;
            }
                
        }
    }

    public void ClickToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
