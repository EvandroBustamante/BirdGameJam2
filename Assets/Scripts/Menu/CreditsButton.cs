using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour, IPointerEnterHandler
{
    private Animator creditsPanel;
    private Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        creditsPanel = GameObject.Find("CreditsPanel").GetComponent<Animator>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        AudioManager.Instance.PlayMenuConfirm();
        creditsPanel.SetTrigger("Toggle");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayMenuHover();
    }
}
