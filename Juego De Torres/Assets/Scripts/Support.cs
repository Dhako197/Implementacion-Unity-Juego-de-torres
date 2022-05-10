using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour
{
    [SerializeField]
    private int valor;

    public int Valor { get => valor; }
    private TextMesh valorText;

    // Start is called before the first frame update
    void Start()
    {
        valorText = this.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        valorText.text = "+" + valor.ToString();
    }
}
