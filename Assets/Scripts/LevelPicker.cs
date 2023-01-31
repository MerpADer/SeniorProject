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

    [SerializeField] GameObject levelPickCanvas;

    [SerializeField] List<Button> buttons;

    void Awake()
    {
        sceneEditor = FindObjectOfType<SceneEditor>();
        player = FindObjectOfType<Movement>().gameObject;
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
        }
    }

    private void Update()
    {
        if (revealObj.isRevealed && Input.GetKeyDown(KeyCode.E))
        {
            openOptions();
        }
    }

    private void openOptions()
    {
        // freeze player movement
        player.GetComponent<Movement>().enabled = false;

        // open choice menu
        levelPickCanvas.SetActive(true);
    }

}
