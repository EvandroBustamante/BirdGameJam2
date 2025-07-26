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
            draggedBird.GetComponent<Transform>().DOShakeScale(shakeEffectDuration, new Vector3(shakeEffectStrength, shakeEffectStrength, 0));
            isDragging = true;
            beginDragEvent.Invoke();
        }
    }

    public void OnReleaseLeftMouse(InputValue value)
    {
        if (draggedBird)
        {
            draggedBird.ReturnPosition();
            draggedBird.GetComponent<Transform>().DOShakeScale(shakeEffectDuration, new Vector3(shakeEffectStrength, shakeEffectStrength, 0));
        }
        draggedBird = null;
        isDragging = false;
        endDragEvent.Invoke();
    }

}
