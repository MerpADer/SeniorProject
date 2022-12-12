using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAdvancer : MonoBehaviour
{
    [SerializeField] QuestAssigner quest;
    [SerializeField] int questStepIndex;

    private TypeOfStep typeOfStep;

    private GameObject textBox;

    private void Awake()
    {
        typeOfStep = quest.questSteps[questStepIndex].typeOfStep;
        if (typeOfStep == TypeOfStep.Talk)
        {
            textBox = GetComponentInChildren<TextBox>().gameObject;
        }
        else if (typeOfStep == TypeOfStep.EnterArea)
        {
            textBox = GetComponentInChildren<TextBox>().gameObject;
        }
    }

    private void Update()
    {
        if (textBox == null && questStepIndex == quest.questStepIndex)
        {
            quest.questStepIndex++;
            Destroy(this);
        }
    }

}
