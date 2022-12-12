using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAssigner : MonoBehaviour
{

    // not used rn, but will be used to set the main quest upon entering a stage
    [SerializeField] bool isNativeQuest;

    public string questName;
    public List<QuestStep> questSteps;
    public int questStepIndex;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

public enum TypeOfStep
{
    Talk,
    EnterArea,
    Kill
}
