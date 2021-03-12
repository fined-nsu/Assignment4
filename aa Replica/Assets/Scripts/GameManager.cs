using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    public GameObject panel;
    public Text playerNameText;
    public Text livesText;
    public Text timerText;

    private int playerLives;
    private string playerName;
    public int timerValue;
    public Rotator rotator;
    public Spawner sp;

    public Animator animator;

    private void Start()
    {
        panel.SetActive(false);
        playerName = PlayerPrefs.GetString("Player");
        playerLives = PlayerPrefs.GetInt("Lives");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            sp.enabled = false;
        }
        timerText.text = "Time Remaining: " + timerValue;
        livesText.text = "Lives: " + playerLives;
        playerNameText.text = "Player: " + playerName;
    }

    public void EndGame()
    {
        
        if (gameHasEnded)
            return;
        
        rotator.enabled = false;
        sp.enabled = false;

        animator.SetTrigger("EndGame");

        gameHasEnded = true;
    }

    public void RestartLevel()
    {
        playerLives--;
        if (playerLives == 0 || timerValue == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
