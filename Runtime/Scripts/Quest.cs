
using System.Collections.Generic;

namespace MyUnityPackage.Quests
{
    public class Quest
    {
        public string Title;
        public string description;
        public List<IQuestObjective> Objectives;
        public bool IsCompleted = false; 

        public Quest(string title, string description, List<IQuestObjective> objectives)
        {
            
        }

    }
}