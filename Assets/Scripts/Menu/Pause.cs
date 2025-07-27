using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Button pauseButton;
    private Button resumeButton;
    private Button homeButton;
    private GameObject pausePanel;

    private bool isOpen = false;

    private void Awake()
    {
        pausePanel = GameObject.Find("PausePanel");
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        resumeButton = pausePanel.transform.Find("ResumeButton").GetComponent<Button>();
        homeButton = pausePanel.transform.Find("HomeButton").GetComponent<Button>();

        pauseButton.onClick.AddListener(TogglePauseMenu);
        resumeButton.onClick.AddListener(TogglePauseMenu);
        homeButton.onClick.AddListener(ReturnHome);

        pausePanel.SetActive(false);
    }

    private void TogglePauseMenu()
    {
        if (!isOpen)
        {
            pausePanel.SetActive(true);
            isOpen = true;
            AudioManager.Instance.PlayUIPause();
        }
        else
        {
            pausePanel.SetActive(false);
            isOpen = false;
            AudioManager.Instance.PlayUIReturn();
        }
    }

    private void ReturnHome()
    {
        AudioManager.Instance.PlayUISelect();
        SceneManager.LoadScene("MainMenu");
    }
}
