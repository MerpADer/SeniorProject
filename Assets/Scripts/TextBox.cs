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
    [SerializeField] TMP_Text nametxt;
    [SerializeField] TMP_Text diatxt;
    [SerializeField] Image backText;

    // info needed to run through text loop
    [SerializeField] string Name;
    [SerializeField] List<string> Dialogue;
    private int currIndex = 0;
    
    // stop any player movement 
    private bool lockPlayer = false;

    private void Awake()
    {
        // initialize variables
        nametxt = GameObject.Find("nameText").GetComponent<TMP_Text>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        Player = FindObjectOfType<Movement>().gameObject;
    }

    void Update()
    {
        // if it's within .3 of the text box then it will reveal the text box
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < 0.3f)
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

        // press any key to progress dialogue
        if (lockPlayer && Input.anyKeyDown)
        {
            // "" will signify the end of the sequence
            // namechange will change the character who is talking
            if (TextPrint(currIndex).Length > 10 && TextPrint(currIndex).Substring(0, 10) == "namechange")
            {
                Name = TextPrint(currIndex).Substring(10);
                currIndex++;
            }
            if (TextPrint(currIndex) != "")
            {
                backText.gameObject.SetActive(true);
                nametxt.text = Name;
                diatxt.text = TextPrint(currIndex);
            }
            // turn all the UI for text off and unlock player
            else
            {
                backText.gameObject.SetActive(false);
                nametxt.text = "";
                diatxt.text = "";
                Player.GetComponent<Movement>().enabled = true;
                Destroy(gameObject);
            }
            currIndex++;
        }
    }

    // method that returns the current text index associated with i
    private string TextPrint (int i)
    {
        if (i < Dialogue.Count)
        {
            return Dialogue[i];
        }
        return "";
    }
}
