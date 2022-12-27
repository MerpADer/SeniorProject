using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReceptor : MonoBehaviour
{

    [SerializeField] TypeOfChange typeOfChange;
    [SerializeField] GameObject targetGameObject;

    [SerializeField] int thisStepIndex;
    [SerializeField] QuestAssigner quest;

    void Update()
    {
        if (quest.questStepIndex == thisStepIndex)
        {
            if (typeOfChange == TypeOfChange.Spawn)
            {
                Instantiate(targetGameObject, gameObject.transform.position, Quaternion.identity);
                Destroy(this);
            }
        }
    }
}

enum TypeOfChange
{
    Spawn
}