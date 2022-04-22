using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MenuManager
{
    public bool gameIsPaused = false;

    public static PauseMenu MenuInstance;

    private void Awake() {
        MenuInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            
        }
    }

   public void Pause(){
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume(){
        menu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
