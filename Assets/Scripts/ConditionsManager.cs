using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConditionsManager : MonoBehaviour
{
    public string nextLevel;
    public float failPopUpTimeActive = 3.0f;

    private Bird[] AllBirds;
    private bool allBirdsSatisfied;
    private bool runningFailCoroutine = false;

    private Button CompleteCheckButton;
    private GameObject failPopUp;

    private void Awake()
    {
        AllBirds = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        CompleteCheckButton = GameObject.Find("CompleteCheckButton").GetComponent<Button>();
        failPopUp = GameObject.Find("FailPopUp");

        CompleteCheckButton.onClick.AddListener(CompleteCheckButtonClick);
        failPopUp.SetActive(false);
    }

    public void CheckAllBirds()
    {
        int birdsSatisfied = 0;
        foreach (Bird Bird in AllBirds)
        {
            Bird.CheckForConditionsMet();
            if (Bird.isSatisfied)
                birdsSatisfied++;
        }

        Debug.Log("Birds satisfied: " + birdsSatisfied + "/" + AllBirds.Length);

        if(birdsSatisfied == AllBirds.Length)
        {
            allBirdsSatisfied = true;
            AudioManager.Instance.PlayBirdHappy();
        }
        else
        {
            allBirdsSatisfied = false;
            AudioManager.Instance.PlayBirdSad();
        }
    }

    private void CompleteCheckButtonClick()
    {
        if (allBirdsSatisfied)
        {
            StartCoroutine(SuccessTimer());
        }
        else
        {
            if(!runningFailCoroutine)
                StartCoroutine(FailPopUpTimer());
        }
    }

    private IEnumerator FailPopUpTimer()
    {
        AudioManager.Instance.PlayStageFail();
        runningFailCoroutine = true;
        failPopUp.SetActive(true);

        yield return new WaitForSeconds(failPopUpTimeActive);
        failPopUp.SetActive(false);
        runningFailCoroutine = false;
    }

    private IEnumerator SuccessTimer()
    {
        AudioManager.Instance.PlayStageConfirm();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }

}
