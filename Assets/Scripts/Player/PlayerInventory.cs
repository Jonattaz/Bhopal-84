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
        // Verificar o nome do item

        QuestItem(item);
        UI.instaceUI.SetItems(item, items.Count);
        items.Add(item);
    }


    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            return;
        }
        UI.instaceUI.UseItems(item, items.Count);
        items.Remove(item);
    }

    public void QuestItem(Item item){

        if(QuestGiver.instance.neededItemHolder == item.itemName){
            print("Item correto coletado");
        }else{
            print("Noooooo");
            // O nome do needed item não está sendo atribuido
            print(QuestGiver.instance.neededItemHolder + " needed item");
            print(item.itemName + " collected item");
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
