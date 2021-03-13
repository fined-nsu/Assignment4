using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    public Button resumeButton;
    public Button saveButton;
    public Button loadButton;
    public Button exitButton;
    public GameObject panel;
    public Spawner sp;

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        sp.enabled = true;

    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("RemainingTime", GameManager.timerValue);
        PlayerPrefs.SetInt("RemainingLives", GameManager.playerLives);
        PlayerPrefs.SetInt("CurrentScore", Score.PinCount);
    }

    public void LoadGame()
    {
        GameManager.timerValue = PlayerPrefs.GetFloat("RemainingTime");
        GameManager.playerLives = PlayerPrefs.GetInt("RemainingLives");
        Score.PinCount = PlayerPrefs.GetInt("CurrentScore");
        
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
