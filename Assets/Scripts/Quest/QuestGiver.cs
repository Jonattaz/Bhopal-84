using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerQuests playerQuests;

    public GameObject questWindow;
    public Text title;
    public Text description;
    public Text neededItem;
    

    public void OpenQuestWindoow(){
        questWindow.SetActive(true);

        title.text = quest.title;
        description.text = quest.title;
        neededItem.text = quest.neededItem;
    }

    public void AcceptQuest(){
        questWindow.SetActive(false);
        quest.isActive = true;
        // Entregar a quest para o jogador, fazer um alg para adicionar várias quest em posições diferentes
        playerQuests.quests[0] = quest;

        
    }

}
