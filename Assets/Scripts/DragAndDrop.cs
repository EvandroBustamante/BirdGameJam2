using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class DragAndDrop : MonoBehaviour
{
    private Bird draggedBird;
    private bool isDragging;
    private Vector3 draggedTransform;

    public UnityEvent beginDragEvent;
    public UnityEvent endDragEvent;

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
            isDragging = true;
            beginDragEvent.Invoke();
        }
    }

    public void OnReleaseLeftMouse(InputValue value)
    {
        if (draggedBird)
            draggedBird.ReturnPosition();
        draggedBird = null;
        isDragging = false;
        endDragEvent.Invoke();
    }

}
