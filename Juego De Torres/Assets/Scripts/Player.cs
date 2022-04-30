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
   
    // Start is called before the first frame update
    void Start()
    {
        //poderText.text = Poder.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        vidasText.text = "Vidas: " + Vidas.ToString();
        if (Vidas <= 0) Destroy(gameObject);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int poderEnemigo = collision.gameObject.GetComponent<Enemy>().Poder;

            if( poderEnemigo >= Poder)
            {
                Vidas--;

                Invoke("RestartPos", 2f);
            }
            else
            {
                Poder += collision.gameObject.GetComponent<Enemy>().Poder;
                collision.GetComponent<Enemy>().DestroyEnemy();
                Invoke("RestartPos", 2f);
            }
           
        }
    }

    private void RestartPos()
    {
        this.GetComponent<Draggable>().RestartPosition();
    }

   
}
