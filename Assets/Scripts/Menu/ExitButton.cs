using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour, IPointerEnterHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayMenuHover();
    }
}
