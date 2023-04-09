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

    [Header("Button Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip canBuy;
    [SerializeField] AudioClip cannotBuy;

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

        public TypeOfItem typeOfItem;

        private GameObject playerObj;

        public Sprite itemImg;
        [HideInInspector] public string itemDesc;

        public void SetValue()
        {
            value = Random.Range(min, max + 1);
        }

        public void SetDesc()
        {
            if (typeOfItem == TypeOfItem.Potion)
            {
                itemDesc = "Heal for " + value.ToString() + " health.";
            }
            else if (typeOfItem == TypeOfItem.AttackUpgrade)
            {
                itemDesc = "Deal " + value.ToString() + " more damage.";
            }
        }

        public int GetValue()
        {
            return value;
        }

        public void UseItem()
        {
            playerObj = FindObjectOfType<Movement>().gameObject;

            if (typeOfItem == TypeOfItem.Potion)
            {
                Health playerHealth = playerObj.GetComponent<Health>();
                playerHealth.hp += value;
                if (playerHealth.hp > playerHealth.maxHealth)
                {
                    playerHealth.hp = playerHealth.maxHealth;
                }
                playerHealth.healthBar.SetHealth(playerHealth.hp);
            }
            else if (typeOfItem == TypeOfItem.AttackUpgrade)
            {
                playerObj.GetComponentInChildren<AttackStats>().AttackDmg += value;
            }
        }

    }

    [System.Serializable]
    public struct ItemSlot 
    {
        public TMP_Text descTxt;
        public TMP_Text priceTxt;
        public Image itemImage;
        public Button button;

        private Movement playerObj;

        [HideInInspector] public int price;

        public int CalculatePrice(int value)
        {
            return (value * 20 + Random.Range(0, 5)); 
        }

        public void PurchaseItem(ItemStats selectedItem, AudioSource audio, AudioClip canBuy, AudioClip cannotBuy)
        {
            playerObj = FindObjectOfType<Movement>();

            if (playerObj.money >= price)
            {
                playerObj.money -= price;
                playerObj.moneyText.text = playerObj.money.ToString();
                selectedItem.UseItem();
                audio.PlayOneShot(canBuy);
                Destroy(button.gameObject);
            }
            else
            {
                audio.PlayOneShot(cannotBuy);
            }
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

            ItemSlot temp = itemSlots[i];

            temp.price = itemSlots[i].CalculatePrice(selectedItem.GetValue());
            itemSlots[i] = temp;

            itemSlots[i].priceTxt.text = itemSlots[i].price.ToString();

            // finally add onClick events for applying item effects and taking money
            itemSlots[i].button.onClick.AddListener(delegate { temp.PurchaseItem(selectedItem, audioSource, canBuy, cannotBuy); });
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
        player.GetComponent<Movement>().enabled = !player.GetComponent<Movement>().enabled;
        shopMenu.SetActive(!shopMenu.activeSelf);
        player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
    } 

}
