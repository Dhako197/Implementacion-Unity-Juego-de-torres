using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int poder = 5;
    public int Poder { get => poder; }

    private TextMesh poderText;
    // Start is called before the first frame update
    void Start()
    {
        poderText = this.GetComponentInChildren<TextMesh>();
    }
    
    // Update is called once per frame
    void Update()
    {
        poderText.text = poder.ToString();
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
