using System.Collections.Generic;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    [CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObjects/Quest/QuestDataSO")]
    public class QuestDataSO : ScriptableObject
    {
        public string id;    
        public string title;
        [TextArea] public string description;
        public List<QuestStepDataSO> steps;
        
        public Quest CreateRuntimeQuest()
        {
            var runtimeSteps = new List<QuestStep>();
            foreach (var data in steps)
                runtimeSteps.Add(data.CreateRuntimeStep());

            return new Quest(id, title, description, runtimeSteps);
        }
    }
}