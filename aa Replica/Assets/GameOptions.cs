using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public InputField playerName;
    public Dropdown livesSelector;
    public Dropdown timeSelector;
    public Slider rotationSpeed;
    public Slider pinSpeed;
    public Button startGame;

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("Player", playerName.text);
    }
    public void SavePlayerLives()
    {
        int caseValue = livesSelector.value;
        int livesValue;
        switch(caseValue)
        {
            case 0:
                livesValue = 3;
                break;
            case 1:
                livesValue = 2;
                break;
            case 2:
                livesValue = 4;
                break;
            case 3:
                livesValue = 6;
                break;
            default:
                livesValue = 3;
                break;
        }
        PlayerPrefs.SetInt("Lives", livesValue);
    }

    public void SaveGameTimer()
    {
        int caseValue = timeSelector.value;
        int timeValue;
        switch(caseValue)
        {
            case 0:
                timeValue = 30;
                break;
            case 1:
                timeValue = 20;
                break;
            case 2:
                timeValue = 40;
                break;
            case 3:
                timeValue = 60;
                break;
            default:
                timeValue = 30;
                break;
        }
        PlayerPrefs.SetFloat("Time", timeValue);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }

    public void ChangeRotationSpeed()
    {
        Rotator.speed = 100f;
        Debug.Log(Rotator.speed);
        PlayerPrefs.SetFloat("RotationSpeed", rotationSpeed.value);
    }

    public void ChangePinSpeed()
    {
        Pin.speed = 100f;
        Debug.Log(Pin.speed);
        PlayerPrefs.SetFloat("PinSpeed", pinSpeed.value);
    }
}
