using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallBack;

    private bool isDragged = false;
    private Vector3 startMousePosition;
    private Vector3 startSpritePosition;
    public Vector3 restartPos;

    void Start()
    {
        
        restartPos = this.transform.localPosition;
    }
    private void OnMouseDown()
    {
        isDragged = true;
        startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startSpritePosition = transform.localPosition;

    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition= startSpritePosition +(Camera.main.ScreenToWorldPoint(Input.mousePosition)- startMousePosition);
        }


    }
    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallBack(this);
       
    }
}
