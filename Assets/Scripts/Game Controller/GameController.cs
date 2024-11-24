using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public GamePausedScreen gamePausedScreen;

    private bool isOver = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePausedScreen.Activate();
        }
    }

    public void GameOver(string deathPlayer)
    {
        if (isOver == true) return; // prevent pop up game over screen again after the game has ended

        isOver = true;
        string gameOverMsg;

        if (deathPlayer == "Maypul") gameOverMsg = "Shovel Knight wins!";
        else if (deathPlayer == "ShovelKnight") gameOverMsg = "Maypul wins!";
        else gameOverMsg = "Draw!";

        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();

        gameOverScreen.Activate(gameOverMsg);
    }
}
