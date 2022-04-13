using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopUp : MonoBehaviour
{
    // GameObject do dialogo
    public GameObject dialog;
    
    // Bool que avança o primeiro dialogo
    //public static bool advanceDialog;

    [SerializeField]private string tagName;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagName))
        { 
            //Player.talking = true;
            dialog.SetActive(true);
            //GameManager.dialogMode = true;
            //advanceDialog = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag(tagName))
        {
            dialog.SetActive(false);
           // GameManager.dialogMode = false;
           // GameManager.offense = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag(tagName))
        {
           // GameManager.offense = false;
        }
    }

}
