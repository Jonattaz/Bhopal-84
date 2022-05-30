using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MenuManager
{
    public GameObject[] screens;
    [SerializeField]
    int index;
    
    // Start is called before the first frame update
    void Start()
    {       
       index = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NextCredit(){
       int i;
       index++;
       i = index;
       
       screens[i--].SetActive(false);
       screens[index].SetActive(true);
    }

    public void PreviousCredit(){
        int i;
        index--;
        i = index;
             
        screens[++i].SetActive(false);
        screens[index].SetActive(true);
    }

}
