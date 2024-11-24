using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameOverScreen : MonoBehaviour
{
    public Text playerWinText;

    public void Activate(string message)
    {
        gameObject.SetActive(true);
        playerWinText.text = message;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
