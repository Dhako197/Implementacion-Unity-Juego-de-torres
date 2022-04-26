using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Vidas= 3;
    public int Poder=5;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Poder <= 0) Destroy(gameObject);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Poder-= collision.gameObject.GetComponent<Enemy>().Poder;
           
        }
    }
}
