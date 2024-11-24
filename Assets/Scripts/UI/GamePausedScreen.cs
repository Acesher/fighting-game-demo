using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedScreen : MonoBehaviour
{
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void OnClickContinue()
    {
        gameObject.SetActive(false);
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
