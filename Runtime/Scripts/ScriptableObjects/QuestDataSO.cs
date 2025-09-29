using System.Collections.Generic;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    [CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObjects/Quest/QuestDataSO")]
    public class QuestDataSO : ScriptableObject
    {
        [SerializeField] private string id;    
        [SerializeField] private string title;
        [TextArea] [SerializeField] private string description;
        [SerializeField] private List<QuestStepDataSO> steps;
        
        public Quest CreateRuntimeQuest()
        {
            var runtimeSteps = new List<QuestStep>();
            foreach (var data in steps)
                runtimeSteps.Add(data.CreateRuntimeStep());

            return new Quest(id, title, description, runtimeSteps);
        }
    }
}