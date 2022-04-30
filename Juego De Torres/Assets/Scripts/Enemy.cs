using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Poder = 5;
    private Vector2 parentPos;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.transform.localPosition = collision.transform.localPosition;
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
