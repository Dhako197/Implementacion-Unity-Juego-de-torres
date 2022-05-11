using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallBack;

    public static bool isDragged = false;
    private Vector3 startMousePosition;
    private Vector3 startSpritePosition;
    public Vector3 restartPos;

    void Start()
    {       
        restartPos = this.transform.position;
    }
    private void OnMouseDown()
    {
        isDragged = true;
        startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startSpritePosition = transform.position;
    }
   
    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.position= startSpritePosition +(Camera.main.ScreenToWorldPoint(Input.mousePosition)- startMousePosition);
        }
    }
    
    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallBack(this);    
    }
    
    public void RestartPosition()
    {
        this.transform.position = restartPos;
    }
}
