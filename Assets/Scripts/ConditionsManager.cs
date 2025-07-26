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
        }
        else
        {
            allBirdsSatisfied = false;
        }
    }

    private void CompleteCheckButtonClick()
    {
        if (allBirdsSatisfied)
        {
            //Feddback de vitória
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            if(!runningFailCoroutine)
                StartCoroutine(FailPopUpTimer());
        }
    }

    private IEnumerator FailPopUpTimer()
    {
        runningFailCoroutine = true;
        failPopUp.SetActive(true);

        yield return new WaitForSeconds(failPopUpTimeActive);
        failPopUp.SetActive(false);
        runningFailCoroutine = false;
    }

}
