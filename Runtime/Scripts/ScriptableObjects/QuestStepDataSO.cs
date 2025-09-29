using System.Collections.Generic;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{   
    [CreateAssetMenu(fileName = "QuestStepDataSO", menuName = "ScriptableObjects/Quest/QuestStepDataSO")]
    public class QuestStepDataSO : ScriptableObject
    {
        [SerializeField] private List<ObjectiveDataSO> objectives;
        
        public QuestStep CreateRuntimeStep()
        {
            var runtimeObjectives = new List<IQuestObjective>();
            foreach (var data in objectives)
                runtimeObjectives.Add(data.CreateRuntimeObjective());

            return new QuestStep(runtimeObjectives);
        }


    }
}