using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    public string sceneToLoad;
    public Image whiteScreen;
    public float fadeDuration;
    public Transform[] birds;
    public Vector2 cooldownRandom;

    private void Start()
    {
        AudioManager.Instance.PlayAmbDay();

        FindFirstObjectByType<DialogueManager>().OnDialogueEnd.AddListener(OnDialogueEnd);

        foreach (Transform Bird in birds)
        {
            float randomCD = Random.Range(cooldownRandom.x, cooldownRandom.y);
            StartCoroutine(BirdJump(Bird, randomCD));
        }
    }

    private void OnDialogueEnd()
    {
        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1f);

        whiteScreen.DOFade(1, fadeDuration);

        yield return new WaitForSeconds(fadeDuration + 1);

        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator BirdJump(Transform bird, float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        bird.DOJump(bird.transform.position, 1, 2, 0.3f);
        float randomCD = Random.Range(cooldownRandom.x, cooldownRandom.y);
        StartCoroutine(BirdJump(bird, randomCD));
    }
}
