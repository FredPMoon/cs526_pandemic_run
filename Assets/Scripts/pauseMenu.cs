using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                DeactiveMenu();
                isPaused = false;
            }
            else {
                ActiveMenu();
                isPaused = true;
            }
        }
    }

    public void ActiveMenu() {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void DeactiveMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    public void CreditMenuOpened() {
        pauseMenuUI.SetActive(false);
    }

    public void CreditMenuClosed() {
        pauseMenuUI.SetActive(true);
    }
}
