using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Ambience")]
    [SerializeField] private EventReference ambDay;

    [Header("Music")]
    [SerializeField] private EventReference musicMenu;
    [SerializeField] private EventReference musicLevelDay;

    [Header("SFX Birds")]
    [SerializeField] private EventReference corujinhaDoMato;
    [SerializeField] private EventReference queroQuero;
    [SerializeField] private EventReference sairaLenco;
    [SerializeField] private EventReference tangara;
    [SerializeField] private EventReference topetinhoVermelho;
    [SerializeField] private EventReference urubuDeCabecaVermelha;
    [SerializeField] private EventReference carcara;

    [Header("SFX Gameplay")]
    [SerializeField] private EventReference birdHappy;
    [SerializeField] private EventReference birdSad;
    [SerializeField] private EventReference birdWaveFinish;
    [SerializeField] private EventReference birdWaveEnd;
    [SerializeField] private EventReference dialogueClose;
    [SerializeField] private EventReference dialogueNext;
    [SerializeField] private EventReference dialoguePopUp;
    [SerializeField] private EventReference dialogueText;
    [SerializeField] private EventReference drag;
    [SerializeField] private EventReference drop;
    [SerializeField] private EventReference stageConfirm;
    [SerializeField] private EventReference stageFail;

    [Header("SFX UI")]
    [SerializeField] private EventReference uiHover;
    [SerializeField] private EventReference menuBack;
    [SerializeField] private EventReference menuConfirm;
    [SerializeField] private EventReference menuFader;
    [SerializeField] private EventReference menuHover;
    [SerializeField] private EventReference pause;
    [SerializeField] private EventReference uiReturn;
    [SerializeField] private EventReference uiSelect;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void StopAll()
    {
        RuntimeManager.GetBus("Bus:/").stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    #region Amb
    public void PlayAmbDay()
    {
        RuntimeManager.PlayOneShot(ambDay);
    }
    #endregion

    #region Music
    public void PlayMusicMenu()
    {
        RuntimeManager.PlayOneShot(musicMenu);
    }

    public void PlayMusicLevelDay()
    {
        RuntimeManager.PlayOneShot(musicLevelDay);
    }
    #endregion

    #region SFX Birds
    public void PlayCorujinhaDoMato()
    {
        RuntimeManager.PlayOneShot(corujinhaDoMato);
    }

    public void PlayQueroQuero()
    {
        RuntimeManager.PlayOneShot(queroQuero);
    }

    public void PlaySairaLenco()
    {
        RuntimeManager.PlayOneShot(sairaLenco);
    }

    public void PlayTangara()
    {
        RuntimeManager.PlayOneShot(tangara);
    }

    public void PlayTopetinhoVermelho()
    {
        RuntimeManager.PlayOneShot(topetinhoVermelho);
    }

    public void PlayUrubuDeCabecaVermelha()
    {
        RuntimeManager.PlayOneShot(urubuDeCabecaVermelha);
    }

    public void PlayCarcara()
    {
        RuntimeManager.PlayOneShot(carcara);
    }

    #endregion

    #region SFX Gameplay
    public void PlayBirdHappy()
    {
        RuntimeManager.PlayOneShot(birdHappy);
    }

    public void PlayBirdSad()
    {
        RuntimeManager.PlayOneShot(birdSad);
    }

    public void PlayBirdWaveFinish()
    {
        RuntimeManager.PlayOneShot(birdWaveFinish);
    }

    public void PlayBirdWaveEnd()
    {
        RuntimeManager.PlayOneShot(birdWaveEnd);
    }

    public void PlayDialogueClose()
    {
        RuntimeManager.PlayOneShot(dialogueClose);
    }

    public void PlayDialogueNext()
    {
        RuntimeManager.PlayOneShot(dialogueNext);
    }

    public void PlayDialoguePopUp()
    {
        RuntimeManager.PlayOneShot(dialoguePopUp);
    }

    public void PlayDialogueText()
    {
        RuntimeManager.PlayOneShot(dialogueText);
    }

    public void PlayDrag()
    {
        RuntimeManager.PlayOneShot(drag);
    }

    public void PlayDrop()
    {
        RuntimeManager.PlayOneShot(drop);
    }

    public void PlayStageConfirm()
    {
        RuntimeManager.PlayOneShot(stageConfirm);
    }

    public void PlayStageFail()
    {
        RuntimeManager.PlayOneShot(stageFail);
    }

    #endregion

    #region SFX UI

    public void PlayUIHover()
    {
        RuntimeManager.PlayOneShot(uiHover);
    }

    public void PlayMenuBack()
    {
        RuntimeManager.PlayOneShot(menuBack);
    }

    public void PlayMenuConfirm()
    {
        RuntimeManager.PlayOneShot(menuConfirm);
    }

    public void PlayMenuFader()
    {
        RuntimeManager.PlayOneShot(menuFader);
    }

    public void PlayMenuHover()
    {
        RuntimeManager.PlayOneShot(menuHover);
    }

    public void PlayUIPause()
    {
        RuntimeManager.PlayOneShot(pause);
    }

    public void PlayUIReturn()
    {
        RuntimeManager.PlayOneShot(uiReturn);
    }

    public void PlayUISelect()
    {
        RuntimeManager.PlayOneShot(uiSelect);
    }

    #endregion
}
