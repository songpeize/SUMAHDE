using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private PopupController popupcontroller;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        popupcontroller.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPaused == false)
        {
            PauseGame();
            popupcontroller.Open();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void RestartPvP()
    {
        StartGame();
        SceneManager.LoadScene("PVP");
    }

    public void RestartPvE()
    {
        StartGame();
        SceneManager.LoadScene("PVE");
    }


    public void StartGame()
    {
        popupcontroller.Close();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void RTS()
    {
        StartGame();
        SceneManager.LoadScene("StartScene");
    }

    public void RCSPVP()
    {
        StartGame();
        SceneManager.LoadScene("pvpSelection");
    }

    public void RCSPVE()
    {
        StartGame();
        SceneManager.LoadScene("pveselection");
    }

    public void Credits()
    {
        StartGame();
        SceneManager.LoadScene("Credits");
    }
}
