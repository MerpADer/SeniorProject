using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{

    private GameObject Player;

    private SpriteRenderer spr;

    [SerializeField] TMP_Text nametxt;
    [SerializeField] TMP_Text diatxt;
    [SerializeField] Image backText;

    [SerializeField] string Name;

    [SerializeField] List<string> Dialogue;
    private int currIndex = 0;

    private bool lockPlayer = false;

    private void Awake()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        Player = FindObjectOfType<Movement>().gameObject;
    }

    void Update()
    {
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < 0.3f)
        {
            spr.enabled = true;
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

        if (lockPlayer && Input.anyKeyDown)
        {
            if (TextPrint(currIndex) != "")
            {
                backText.gameObject.SetActive(true);
                nametxt.text = Name;
                diatxt.text = TextPrint(currIndex);
            }
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

    private string TextPrint (int i)
    {
        if (i < Dialogue.Count)
        {
            return Dialogue[i];
        }
        return "";
    }
}
