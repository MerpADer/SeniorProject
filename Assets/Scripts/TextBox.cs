using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{

    private GameObject Player;
    private SpriteRenderer spr;

    // all the UI variables, maybe find a way to make these private
    [Header("UI variables (always the same)")]
    [SerializeField] TMP_Text nametxt;
    [SerializeField] TMP_Text diatxt;
    [SerializeField] Image Portrait;
    [SerializeField] Image backText;

    // info needed to run through text loop
    [Header("Specific text variables")]
    [SerializeField] Sprite PortraitPicture;
    [SerializeField] string Name;
    [SerializeField] List<string> Dialogue;
    private int currIndex = -1;
    
    // stop any player movement 
    private bool lockPlayer = false;

    // reveal chars stuff
    private float timer = 0;
    private int currCharIndex = 0;

    private void Awake()
    {
        // initialize variables
        spr = gameObject.GetComponent<SpriteRenderer>();
        Player = FindObjectOfType<Movement>().gameObject;
    }

    void Update()
    {
        RevealTextSprite();

        RevealTextChar(lockPlayer);

        // press any key to progress dialogue
        if (lockPlayer && Input.anyKeyDown)
        {
            Portrait.sprite = PortraitPicture;
            diatxt.text = "";
            currCharIndex = 0;

            currIndex++;
            // "" will signify the end of the sequence
            // namechange will change the character who is talking
            if (TextPrint(currIndex).Length > 10 && TextPrint(currIndex).Substring(0, 10) == "namechange")
            {
                Name = TextPrint(currIndex).Substring(10);
                currIndex++;
            }
            if (TextPrint(currIndex) != "")
            {
                Portrait.gameObject.SetActive(true);
                backText.gameObject.SetActive(true);
                nametxt.text = Name;
            }
            // turn all the UI for text off and unlock player
            else
            {
                Portrait.gameObject.SetActive(false);
                backText.gameObject.SetActive(false);
                nametxt.text = "";
                diatxt.text = "";
                Player.GetComponent<Movement>().enabled = true;
                Destroy(gameObject);
            }
        }
    }

    private void RevealTextChar(bool isLocked)
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && currCharIndex < TextPrint(currIndex).Length && isLocked)
        {
            diatxt.text += TextPrint(currIndex)[currCharIndex];
            timer = 0.05f;
            currCharIndex++;
        }
    }

    private void RevealTextSprite()
    {
        // if it's within .3 of the text box then it will reveal the text box
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < 0.25f)
        {
            spr.enabled = true;
            // pressing "E" will only work once with the && !lockplayer
            if (Input.GetKeyDown(KeyCode.E) && !lockPlayer)
            {
                lockPlayer = true;
                Player.GetComponent<Movement>().enabled = false;
            }
        }
        else
        {
            spr.enabled = false;
        }
    }

    // method that returns the current text index associated with i
    private string TextPrint (int i)
    {
        if (i < Dialogue.Count && currIndex >= 0)
        {
            return Dialogue[i];
        }
        return "";
    }
}
