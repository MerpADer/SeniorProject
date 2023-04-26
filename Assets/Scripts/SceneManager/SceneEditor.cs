using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Animator anim;

    [Header("Room Stuff")]
    public List<RoomData> Rooms;
    [SerializeField] int roomThreshold;
    [SerializeField] RoomData BossRoom;

    private GameObject optionsMenu;

    private void Start()
    {
        // replace with singleton at some point maybe
        if (gameObject.tag == "SceneEditor")
        {
            DontDestroyOnLoad(gameObject);
        }
        
        // searching children for "OptionsMenu"
        optionsMenu = gameObject.transform.Find("OptionsMenu").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            // either reveals or hides options menu based on what it already was
            optionsMenu.SetActive(!optionsMenu.activeInHierarchy);
        }
    }

    public void fadeOut()
    {
        anim.SetBool("IsFadedOut", true);
        Invoke(nameof(fadeIn), 2f);
    }

    public void fadeIn()
    {
        anim.SetBool("IsFadedOut", false);
    }

    // these 3 methods do stuff when we load a new scene
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    // if I have to do something at the very start a new scene, do it here
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        
    }

    //Scene Manipulation
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }

    // wrapper function for the NextScene coroutine so I can use it on buttons
    public void WrapperNextScene(string SceneName)
    {
        StartCoroutine(NextScene(SceneName));
    }

    public IEnumerator NextScene(string SceneName)
    {
        fadeOut();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // returns a random RoomData from list Rooms
    public RoomData RandomRoom()
    {
        return Rooms[Random.Range(0, Rooms.Count)];
    }

    // removes one RoomData from the list Rooms
    public void RemoveRoom(string sceneName)
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (Rooms[i].nameOfScene == sceneName)
            {
                Rooms.RemoveAt(i);
                break;
            }
        }

        // if the list reaches a certain threshold,
        // then the only room in the list will be a boss room

        if (Rooms.Count < roomThreshold)
        {
            Rooms.Clear();
            Rooms.Add(BossRoom);
        }

    }

}
