using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private GameObject player;
    private RevealObj revealedObj;

    public GameObject shopMenu;

    // item stuff
    public enum TypeOfItem
    {
        Potion,
        AttackUpgrade
    }

    [System.Serializable]
    public struct ItemStats
    {
        public int min;
        public int max;
        private int value;
        public int price;

        public TypeOfItem typeOfItem;

        public Sprite itemImg;
        [HideInInspector] public string itemDesc;

        public void SetValue()
        {
            value = Random.Range(min, max + 1);
            price += value;
        }

        public void SetDesc()
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

        public int GetValue()
        {
            return value;
        }

    }

    [System.Serializable]
    public struct ItemSlot 
    {
        public TMP_Text descTxt;
        public TMP_Text priceTxt;
        public Image itemImage;

        [HideInInspector] public int price;

        public int CalculatePrice(int value)
        {
            return value * 2 + Random.Range(0, 2);
        }

    }

    public List<ItemStats> items;
    public List<ItemSlot> itemSlots;

    void Awake()
    {
        player = FindObjectOfType<Movement>().gameObject;
        revealedObj = GetComponent<RevealObj>();

        //This section sets the item slots to have random items in them with random values
        for (int i = 0; i < itemSlots.Count; i++)
        {
            // first get a random item and set its values
            ItemStats selectedItem = items[Random.Range(0, items.Count)];
            selectedItem.SetValue();
            selectedItem.SetDesc();
            // now set all these values to ui on screen
            itemSlots[i].itemImage.sprite = selectedItem.itemImg;
            itemSlots[i].descTxt.text = selectedItem.itemDesc;
            itemSlots[i].priceTxt.text = itemSlots[i].CalculatePrice(selectedItem.GetValue()).ToString();
        }

    }

    void Update()
    {
        if (revealedObj.isRevealed && Input.GetKeyDown(KeyCode.E))
        {
            openShop();
        }
    }

    public void openShop()
    {
        player.GetComponent<Movement>().enabled = false;
        shopMenu.SetActive(true);
    } 

}
