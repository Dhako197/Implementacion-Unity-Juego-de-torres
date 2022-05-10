using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int vidas = 3;
    [SerializeField]
    private int poder = 5;
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
        vidasText.text = "Vidas: " + vidas.ToString();
        poderText.text = poder.ToString();
        if (vidas <= 0)
        {
            

            Destroy(gameObject);
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& Draggable.isDragged== false)
        {
            int poderEnemigo = collision.gameObject.GetComponent<Enemy>().Poder;

            if( poderEnemigo >= poder)
            {
                vidas--;
                Draggable.isDragged = true;
                Invoke("RestartPos", 2f);
            }
            else
            {
                poder += poderEnemigo;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Support"))
        {
            int valorSupp = collision.gameObject.GetComponent<Support>().Valor;
            poder += valorSupp;
            Destroy(collision.gameObject);
        }
    }


    public void RestartPos()
    {
        this.GetComponent<Draggable>().RestartPosition();
       
    }

   
}
