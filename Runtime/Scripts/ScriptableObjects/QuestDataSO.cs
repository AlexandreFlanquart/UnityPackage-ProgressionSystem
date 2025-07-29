using System.Collections.Generic;
using UnityEngine;

namespace MyUnityPackage.Quests
{
    [CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObjects/Quest/QuestDataSO")]
    public class QuestDataSO : ScriptableObject
    {
        public string title;
        [TextArea] public string description;
        public ObjectiveDataSO[] objectives;
        
        public Quest CreateRuntimeQuest()
        {
            var runtimeObjectives = new List<IQuestObjective>();
            foreach (var data in objectives)
                runtimeObjectives.Add(data.CreateRuntimeObjective());

            return new Quest(title, description, runtimeObjectives);
        }
    }
}