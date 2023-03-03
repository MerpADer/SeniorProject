using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemData : MonoBehaviour
{
    
    public enum TypeOfItem
    {
        Potion,
        AttackUpgrade
    }

    public int value;
    public TypeOfItem typeOfItem;
    public Image itemImg;
    [HideInInspector] public string itemDesc;

    void Awake()
    {
        if (typeOfItem == TypeOfItem.Potion)
        {
            itemDesc = "Heal for " + value.ToString() + " health.";
        }
        else if (typeOfItem == TypeOfItem.AttackUpgrade)
        {
            itemDesc = "Deal " + value.ToString() + " damage.";
        }
    }

}
