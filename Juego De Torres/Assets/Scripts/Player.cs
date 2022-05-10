using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Vidas= 3;
    public int Poder=5;
    //public Text poderText;
    public Text vidasText;
    private TextMesh poderText;
   
    // Start is called before the first frame update
    void Start()
    {
        //poderText.text = Poder.ToString();
       poderText= this.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        vidasText.text = "Vidas: " + Vidas.ToString();
        poderText.text = Poder.ToString();
        if (Vidas <= 0) Destroy(gameObject);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& Draggable.isDragged== false)
        {
            int poderEnemigo = collision.gameObject.GetComponent<Enemy>().Poder;

            if( poderEnemigo >= Poder)
            {
                Vidas--;
                Draggable.isDragged = true;
                Invoke("RestartPos", 2f);
            }
            else
            {
                Poder += poderEnemigo;
                collision.GetComponent<Enemy>().DestroyEnemy();
                
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackPoint"))
        {
            RestartPos();
           
        }
    }

    public void RestartPos()
    {
        this.GetComponent<Draggable>().RestartPosition();
    }

   
}
