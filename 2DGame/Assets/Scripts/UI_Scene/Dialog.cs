using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textGameObject;
    private string text; 
    private void Start()
    {
        text = textGameObject.text;
        textGameObject.text = ""; 
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TextCoroutine());
            Destroy(textGameObject, 3);
        }
    } 

    IEnumerator TextCoroutine()
    {   
        foreach (var item in text)
        {
            textGameObject.text += item;
            yield return new WaitForSeconds(0.1f);
        }
    } 
   
}
