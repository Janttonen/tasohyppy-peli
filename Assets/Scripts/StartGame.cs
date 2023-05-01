using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start the game when button is pressed
    public void StartTheGame()
    {
        ScoreCounter.totalScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Go back to start menu
    public void BackToMenu()
    {
        SceneManager.LoadScene( sceneName: "StartScreen");
    }
    // End the game
    public void Quit()
    {
        Application.Quit();
    }
}
