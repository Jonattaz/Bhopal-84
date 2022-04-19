 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopUp : MonoBehaviour
{
    // GameObject do dialogo
    public GameObject dialog;
    
    [SerializeField]private string tagName;

    [SerializeField]private Image image;

    [SerializeField]private Color endColor;

    [SerializeField]private Color startColor;

    // Start is called before the first frame update
   private void Start() {
       startColor = image.color;
       endColor.a = 1;
   }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagName))
        { 
            image.color = endColor;
            dialog.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag(tagName))
        {
            image.color = startColor;
            dialog.SetActive(false);
        }
    }
}
