using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType GoalType;
    public int requiredAmount;
    public int currentAmount;

    public bool isReached(){
        return (currentAmount >= requiredAmount);
    } 
}


    /* Fazer com que o quest consiga reconhecer quando o jogador coleta o item da missão. 
        Editar o código relacionado a coleta de itens e verificar se o item da missão existe no inventário. Caso verdadeiro a missão termina
        nesse momento ou ele tem que voltar ao npc para "entregar" o item.
        Verificar o tipo de goal que é a quest, se for igual a que o jogador está fazendo então o item é aceito
    */
public enum GoalType{
    CollectItem,
    ItemDelivery
}
