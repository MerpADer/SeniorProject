using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeleteLoadScene : MonoBehaviour
{

    private SceneEditor sceneEditor;

    [SerializeField] string sceneName;

    void Awake()
    {
        sceneEditor = FindObjectOfType<SceneEditor>();
    }

    private void OnDestroy()
    {
        sceneEditor.WrapperNextScene(sceneName);
    }

}
