using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    // Variável que representa a imagem do personagem
    public Image portrait;
    
    // Nome completo do personagem
    public Text fullName;
  
    // Texto que irá receber a fala do personagem
    public Text dialog;

    // Váriavel que representa a classe Character
    private Character speaker;

    public Character Speaker 
    {
        get { return speaker; }
        set 
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
        
        }
    }

    public string Dialog 
    {
        set { dialog.text = value; }
    
    }

    public bool HasSpeaker() 
    {
        return speaker != null;
    
    }

    public bool SpeakerIs(Character character) 
    {
        return speaker == character;
              
    }

    public void Show() 
    {
        gameObject.SetActive(true);
   
    }

    public void Hide() 
    {

        gameObject.SetActive(false);
    
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
