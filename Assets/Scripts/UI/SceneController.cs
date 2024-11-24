using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void FC()
    {
        SceneManager.LoadScene("FireCapital");
    }

    public void RW() {
        SceneManager.LoadScene("TheRockWall");
    }

    public void PK() {
        SceneManager.LoadScene("PridemoorKeep");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void SS() {
        SceneManager.LoadScene("StageSelection");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
