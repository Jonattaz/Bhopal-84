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

    public QuestGiver questGiver;

    // Start is called before the first frame update
   private void Start() {
       startColor = image.color;
       endColor.a = 1;
   }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagName))
        { 
            
            AI.instanceAI.stop = true;
            
           if(AI.instanceAI.canTalk){ 
                image.color = endColor;

               if(questGiver != null){ 
                    if(!questGiver.completed){
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
