using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{

    private GameObject player;
    private SceneEditor sceneEditor; // the scene editor contains the list of rooms
    private RevealObj revealObj;
    private Animator animator;

    [SerializeField] GameObject levelPickCanvas;

    [SerializeField] List<Button> buttons;

    void Awake()
    {
        sceneEditor = FindObjectOfType<SceneEditor>();
        player = FindObjectOfType<Movement>().gameObject;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        revealObj = GetComponent<RevealObj>();

        for (int i = 0; i < buttons.Count; i++)
        {
            // assign name and destination based on a list of scenes
            RoomData randomRoom = sceneEditor.RandomRoom();
            buttons[i].gameObject.GetComponentInChildren<TMP_Text>().text = randomRoom.nameDisplay;
            buttons[i].onClick.AddListener(delegate { StartCoroutine(sceneEditor.NextScene(randomRoom.nameOfScene)); } );
            buttons[i].onClick.AddListener(delegate { sceneEditor.RemoveRoom(randomRoom.nameOfScene); });
            buttons[i].onClick.AddListener(delegate { startAnim(); });
        }
    }

    private void Update()
    {
        if (revealObj.isRevealed && Input.GetKeyDown(KeyCode.E))
        {
            openChoices();
        }
    }

    private void openChoices()
    {
        // freeze and hide player
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;

        // open choice menu
        levelPickCanvas.SetActive(true);
    }

    // This hides the buttons and starts the carriage animation
    private void startAnim()
    {
        revealObj.revealedObj.gameObject.SetActive(false);
        levelPickCanvas.SetActive(false);
        animator.SetBool("isWalking", true);
    }

}
