using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<QuestAssigner> questList;

    private QuestAssigner currentQuest;

    public TMP_Text QuestName;
    public TMP_Text QuestStepDescription;

    void Start()
    {
        currentQuest = questList[0];
    }

    void Update()
    {
        QuestName.text = currentQuest.questName;

        if (currentQuest.questStepIndex >= currentQuest.questSteps.Count)
        {
            QuestStepDescription.text = "Quest Complete";
        }
        else
        {
            //this hurts to read
            QuestStepDescription.text = currentQuest.questSteps[currentQuest.questStepIndex].StepDescription;
        }
    }
}
