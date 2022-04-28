using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items;
 
    [HideInInspector]
    public GameObject itemPrefab;
    public static PlayerInventory instance;

    public Quest quest;

    public QuestGiver[] questGivers;

    public int index = 0;

    [HideInInspector]
    public bool questObjective;
    private void Awake()
    {
        instance = this;
        
    }
    

    public void AddItem(Item item)
    {
        if (items.Contains(item))
        {   
            return;
        }
        UI.instaceUI.SetItems(item, items.Count);
        items.Add(item);
        QuestItem(item);
    }


    // Não Funciona
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            return;
        }
        UI.instaceUI.UseItems(item, items.Count - 1);
        items.Remove(item);
    }

    public void QuestItem(Item item){

        if(questGivers[index].neededItemHolder == item.itemName){
            questObjective = true;
            UI.instaceUI.UseItems(item, items.Count - 1);
        }
    }

    public void SpawnItems(int index)
    {
        if(itemPrefab != null){
            Destroy(itemPrefab);
        }
       QuestItem(items[index]);
       itemPrefab = Instantiate(items[index].prefab, new Vector3(1000,1000,1000), Quaternion.identity);
       UI.instaceUI.Set3DCaptions(items[index].text);
        
        /* 
        =============================================================================================================
        Código para pegar objetos específicos na lista de itens  
        int j;
        j = UI.instaceUI.inventoryItems.Length;
        for (int i = 0; i <= UI.instaceUI.inventoryItems.Length; i++)
        {
            if (j == index)
            { 
                Faça algo
            }
            else
            {
                j--;
            }
        }
        ===============================================================================================================
        */
    }
}
