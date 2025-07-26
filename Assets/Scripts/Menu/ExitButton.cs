using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);

        AudioManager.Instance.PlayMusicMenu();
    }

    private void OnButtonClick()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
