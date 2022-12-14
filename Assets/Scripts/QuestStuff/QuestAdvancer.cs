using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAdvancer : MonoBehaviour
{
    [SerializeField] QuestAssigner quest;
    [SerializeField] int questStepIndex;

    private TypeOfStep typeOfStep;

    private GameObject objective;

    private void Awake()
    {
        typeOfStep = quest.questSteps[questStepIndex].typeOfStep;
        if (typeOfStep == TypeOfStep.Talk)
        {
            objective = GetComponentInChildren<TextBox>().gameObject;
        }
        else if (typeOfStep == TypeOfStep.EnterArea)
        {
            objective = GetComponent<BoxCollider2D>().gameObject;
        }
    }

    private void Update()
    {
        if (objective == null && questStepIndex == quest.questStepIndex)
        {
            quest.questStepIndex++;
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && questStepIndex == quest.questStepIndex)
        {
            quest.questStepIndex++;
            Destroy(gameObject);
        }
    }

}
