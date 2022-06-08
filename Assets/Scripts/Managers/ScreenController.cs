using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MenuManager
{

    
    public GameObject[] screens;
    [SerializeField]
    int index;
    [SerializeField] GameObject VP;

    [SerializeField] bool thereISVP;

    // Start is called before the first frame update
    void Start()
    {       
       index = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update() {
        if(thereISVP)
            InvokeRepeating("checkOver", .1f,.1f);
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
    
    private void checkOver()
    {
       long playerCurrentFrame = VP.GetComponent<UnityEngine.Video.VideoPlayer>().frame;
       long playerFrameCount = System.Convert.ToInt64(VP.GetComponent<UnityEngine.Video.VideoPlayer>().frameCount);
     
       if(playerCurrentFrame < playerFrameCount)
       {
           //print ("VIDEO IS PLAYING");
       }
       else
       {
         //  print ("VIDEO IS OVER");
          //Do w.e you want to do for when the video is done playing.
       
          //Cancel Invoke since video is no longer playing
           CancelInvoke("checkOver");
       }
    }
}
