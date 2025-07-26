using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SceneButton : MonoBehaviour, IPointerEnterHandler
{
    public string sceneName;

    private Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AudioManager.Instance.PlayMenuConfirm();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayMenuHover();
    }
}
