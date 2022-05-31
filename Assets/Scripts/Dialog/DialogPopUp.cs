 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopUp : MonoBehaviour
{
    // GameObject do dialogo
    public GameObject dialogBeforeQuest;
    public GameObject dialogAfterQuest;
    
    [SerializeField]private string tagName;

    [SerializeField]private Image image;

    [SerializeField]private Color endColor;

    [SerializeField]private Color startColor;

    [SerializeField]private bool completedHolder;

    [SerializeField]private bool noQuest;

    public QuestGiver questGiver;

    // Start is called before the first frame update
   private void Start() {
       startColor = image.color;
       endColor.a = 1;
   }
   private void Update() {
       if(questGiver != null)
        completedHolder = questGiver.completed;
   }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagName))
        { 
            
            AI.instanceAI.stop = true;
            
           if(AI.instanceAI.canTalk){ 
                image.color = endColor;
               if(!noQuest){ 
                    if(!completedHolder){
                        dialogBeforeQuest.SetActive(true);
                    }else if(dialogAfterQuest != null){
                        dialogAfterQuest.SetActive(true);
                    }
                }else
                    dialogBeforeQuest.SetActive(true); 

           }
           // print("Quest Giver: Local Active " + questGiver.localActive);
           // print("Player Inventory: Quest Objective " + PlayerInventory.instance.questObjective);
           // print( "Quest Giver: completed " + questGiver.completed);
           // print("Player Inventory: In Quest " + PlayerInventory.instance.inQuest);    
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag(tagName))
        {
            image.color = startColor;
            dialogBeforeQuest.SetActive(false);    
            if(dialogAfterQuest != null)
                dialogAfterQuest.SetActive(false);
        }
    }
}
