using MyUnityPackage.Toolkit;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MyUnityPackage.ProgressionSystem
{
    public class QuestManager : MonoBehaviour
    {
        private QuestUI questUI;
        private Dictionary<string, Quest> questDataDict = new Dictionary<string, Quest>();

        void Awake(){
            questUI = ServiceLocator.GetService<QuestUI>();
        }

        void Start()
        {
            // Load all ScriptableObjects of type QuestDataSO from Resources folder
            var questDatas = Resources.LoadAll<QuestDataSO>("");
            MyUnityPackage.Toolkit.Logger.LogMessage(questDatas.Length + " QuestDataSO loaded");

            // Fill the dictionary
            foreach (var data in questDatas)
            {
                if (!questDataDict.ContainsKey(data.id))
                {
                    questDataDict.Add(data.id, data.CreateRuntimeQuest());
                }
            }
            ActivateQuest("CoinQuest");
        }

        public Quest GetQuestDataByName(string questName)
        {
            questDataDict.TryGetValue(questName, out var quest);
            return quest;
        }

        public void ActivateQuest(string questId)
        {
            var quest = GetQuestDataByName(questId);
            if (quest != null)
            {
                quest.Active(true); 
                questUI.Setup(quest); 
            }
            else
            {
                Debug.LogWarning($"Quest with id {questId} not found.");
            }
        }

    }
}