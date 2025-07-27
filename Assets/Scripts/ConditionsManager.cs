using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

public class ConditionsManager : MonoBehaviour
{
    public string nextLevel;
    public float failPopUpTimeActive = 3.0f;
    public GameObject poofVFX;

    private Bird[] AllBirds;
    private bool allBirdsSatisfied;
    private bool playSadSound = false;
    private bool runningFailCoroutine = false;

    private Button CompleteCheckButton;
    private GameObject failPopUp;

    [HideInInspector] public UnityEvent OnAllBirdsSatisfied;

    private void Awake()
    {
        AllBirds = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        CompleteCheckButton = GameObject.Find("CompleteCheckButton").GetComponent<Button>();
        failPopUp = GameObject.Find("FailPopUp");

        CompleteCheckButton.onClick.AddListener(CompleteCheckButtonClick);
        failPopUp.SetActive(false);
    }

    public void CheckAllBirds(bool wasLastBirdPlacedClearArea)
    {
        playSadSound = false;
        int birdsSatisfied = 0;
        foreach (Bird Bird in AllBirds)
        {
            Bird.CheckForConditionsMet();
            if (Bird.isSatisfied)
            {
                birdsSatisfied++;
            }
            else
            {
                if (Bird.myBirdSlot)
                {
                    playSadSound = true;
                }
            }
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

        if (playSadSound && !wasLastBirdPlacedClearArea)
        {
            AudioManager.Instance.PlayBirdSad();
            //Debug.Log("Played bird sad");
        }
        else if (!playSadSound && !wasLastBirdPlacedClearArea)
        {
            AudioManager.Instance.PlayBirdHappy();
            //Debug.Log("Played bird happy");
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
        AudioManager.Instance.PlayBirdWaveEnd();
        OnAllBirdsSatisfied.Invoke();

        yield return new WaitForSeconds(1f);

        foreach (Bird Bird in AllBirds)
        {
            Instantiate(poofVFX, Bird.transform.position, Quaternion.identity);
            if(Bird.transform.Find("Sprite") != null)
            {
                Bird.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Bird.GetComponent<SpriteRenderer>().enabled = false;
            }
            AudioManager.Instance.PlayBirdWaveFinish();
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1f);

        AudioManager.Instance.StopAll();
        SceneManager.LoadScene(nextLevel);
    }

}
