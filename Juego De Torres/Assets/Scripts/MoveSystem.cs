using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject attackPoint;
    public GameObject[] attackPoint2;
    private bool moving;
    private bool attacking = false;

    private float startPosX;
    private float startPosY;

    private Vector3 restartPos;

    // Start is called before the first frame update
    void Start()
    {
        attackPoint2 = GameObject.FindGameObjectsWithTag("AttackPoint");
        restartPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos= Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        } 

        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos= Input.mousePosition;
            mousePos= Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }


    }
    private void OnMouseUp()
    {
        

        moving = false;
        /*for(int i=0;i < attackPoint2.Length; i++)
        {
            if (Mathf.Abs(this.transform.localPosition.x - attackPoint2[i].transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - attackPoint2[i].transform.localPosition.y) <= 0.5f)
            {
                this.transform.localPosition = new Vector3(attackPoint2[i].transform.localPosition.x, attackPoint2[i].transform.localPosition.y, attackPoint2[i].transform.localPosition.z);
            }
            else
            {
                this.transform.localPosition = new Vector3(restartPos.x, restartPos.y, restartPos.z);
            }
        }
        */
        
        if (Mathf.Abs(this.transform.localPosition.x - attackPoint.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - attackPoint.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = new Vector3(attackPoint.transform.localPosition.x, attackPoint.transform.localPosition.y, attackPoint.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(restartPos.x, restartPos.y, restartPos.z);
        }
        
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackPoint"))
        {
            attacking = true;
            Debug.Log("aaaaaaaaaa");
            this.transform.localPosition = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.localPosition.z);
            
        }
       
    }

    private void Restartposition()
    {
        this.transform.localPosition = new Vector3(restartPos.x, restartPos.y, restartPos.z);
    }
}
