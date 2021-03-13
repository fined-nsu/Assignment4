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

    public static int playerLives = 3;
    private string playerName;
    public static float timerValue = 30f;
    public Rotator rotator;
    public Spawner sp;

    public Animator animator;

    private void Start()
    {
        panel.SetActive(false);
        playerName = PlayerPrefs.GetString("Player");
        playerLives = PlayerPrefs.GetInt("Lives");
        Pin.speed = PlayerPrefs.GetFloat("PinSpeed");
        timerValue = PlayerPrefs.GetFloat("Time");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            sp.enabled = false;
        }
        
        
        livesText.text = "Lives: " + playerLives;
        playerNameText.text = "Player: " + playerName;

        if (timerValue >= 0)
        {
            timerText.text = "Time Remaining: " + timerValue.ToString("F2");
            timerValue -= Time.deltaTime;
        }
        else
        {
            timerText.text = "Time is up!";
            SceneManager.LoadScene(2);
        }
    }

    public void EndGame()
    {
        
        if (gameHasEnded)
            return;
        if (playerLives <= 0)
        {
            rotator.enabled = false;
            sp.enabled = false;
        }

        animator.SetTrigger("EndGame");
        Destroy(Spawner.clone, 0.25f);
        
        if (playerLives <= 0)
        {
            gameHasEnded = true;
        }
    }

    public void RestartLevel()
    {
        playerLives--;
        if (playerLives == 0 || timerValue <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Score.PinCount = 0;

    }
}
