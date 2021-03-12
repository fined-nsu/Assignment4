using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public InputField playerName;
    public Dropdown livesSelector;
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
                livesValue = 2;
                break;
            case 1:
                livesValue = 4;
                break;
            case 2:
                livesValue = 6;
                break;
            default:
                livesValue = 3;
                break;
        }
        PlayerPrefs.SetInt("Lives", livesValue);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
