using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{

    public Transform[] childrens;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        childrens = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        childrens = gameObject.GetComponentsInChildren<Transform>();

        if (childrens.Length <= 2)
        {
           
            Invoke("DestroyFloor", 2.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackPoint"))
        {
            this.transform.localPosition = collision.transform.localPosition;
        }
    }
    
    private void DestroyFloor()
    {

        gameObject.SetActive(false);
       
    }
   
}
