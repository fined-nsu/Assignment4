using UnityEngine;
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



}
