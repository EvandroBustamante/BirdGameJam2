using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using DG.Tweening;

public class DragAndDrop : MonoBehaviour
{
    public float shakeEffectStrength;
    public float shakeEffectDuration;

    private Bird draggedBird;
    private bool isDragging;
    private Vector3 draggedTransform;

    [HideInInspector] public UnityEvent beginDragEvent;
    [HideInInspector] public UnityEvent endDragEvent;

    private void Awake()
    {
        AudioManager.Instance.PlayAmbDay();
        AudioManager.Instance.PlayMusicLevelDay();
    }

    private void Update()
    {
        if(isDragging && draggedBird)
        {
            draggedTransform = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, draggedBird.transform.position.z);
            draggedBird.transform.position = draggedTransform;
        }
    }

    public void OnAttack(InputValue value)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider && hit.collider.CompareTag("Bird"))
        {
            draggedBird = hit.transform.GetComponent<Bird>();
            if(!DOTween.IsTweening(draggedBird.GetComponent<Transform>()))
                draggedBird.GetComponent<Transform>().DOShakeScale(shakeEffectDuration, new Vector3(shakeEffectStrength, shakeEffectStrength, 0));
            isDragging = true;
            beginDragEvent.Invoke();

            AudioManager.Instance.PlayDrag();

            if(draggedBird is CorujinhaDoMato)
            {
                AudioManager.Instance.PlayCorujinhaDoMato();
            }
            else if (draggedBird is QueroQuero)
            {
                AudioManager.Instance.PlayQueroQuero();
            }
            else if (draggedBird is SairaLenco)
            {
                AudioManager.Instance.PlaySairaLenco();
            }
            else if (draggedBird is Tangara)
            {
                AudioManager.Instance.PlayTangara();
            }
            else if (draggedBird is TopetinhoVermelho)
            {
                AudioManager.Instance.PlayTopetinhoVermelho();
            }
            else if (draggedBird is UrubuDeCabecaVermelha)
            {
                //AudioManager.Instance.PlayUrubuDeCabecaVermelha();
            }
            else if (draggedBird is Carcara)
            {
                //AudioManager.Instance.PlayCarcara();
            }
        }
    }

    public void OnReleaseLeftMouse(InputValue value)
    {
        if (draggedBird)
        {
            draggedBird.ReturnPosition();
            draggedBird.GetComponent<Transform>().DOShakeScale(shakeEffectDuration, new Vector3(shakeEffectStrength, shakeEffectStrength, 0));
            AudioManager.Instance.PlayDrop();
        }
        draggedBird = null;
        isDragging = false;
        endDragEvent.Invoke();
    }

}
