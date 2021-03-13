using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameControls : MonoBehaviour
{
    public Button MainMenuButton;
    public Button RetryButton;
    public Button QuitGameButton;
    public Text scoreText;
    public Text livesRemainingText;

    private void Start()
    {
        scoreText.text = "Your score: " + Score.PinCount;
        livesRemainingText.text = "Lives remaining: " + GameManager.playerLives;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }

}
