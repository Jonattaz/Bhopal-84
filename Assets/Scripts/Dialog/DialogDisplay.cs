using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;

    public GameObject speaker_1_GO;

    public GameObject speaker_2_GO;

    private SpeakerUI speakerUI_1;

    private SpeakerUI speakerUI_2;

    private int activeLineIndex = 0;

    public QuestGiver questGiver;

    public Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        speakerUI_2 = speaker_2_GO.GetComponent<SpeakerUI>();
        speakerUI_1 = speaker_1_GO.GetComponent<SpeakerUI>();

        speakerUI_2.Speaker = conversation.speakerLeft;
        speakerUI_1.Speaker = conversation.speakerRight;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AdvanceConversation();
        }
    }

    public void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUI_2.Hide();
            speakerUI_1.Hide();
            activeLineIndex = 0;

            if(conversation.quest && !quest.isActive && !PlayerInventory.instance.questObjective){
                questGiver.OpenQuestWindoow();
            }

            if(PlayerInventory.instance.questObjective){
    
                questGiver.CompleteQuest();
                conversation.quest = false;
            }
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUI_2.SpeakerIs(character))
        {
            SetDialog(speakerUI_2, speakerUI_1, line.text);
        }
        else
        {
            SetDialog(speakerUI_1, speakerUI_2, line.text);
        }
    }

    void SetDialog(
        SpeakerUI activeSpeakerUI,
        SpeakerUI inactiveSpeakerUI,
        string text
    )
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();

        inactiveSpeakerUI.Dialog = text;
        inactiveSpeakerUI.Hide();
    }
}
