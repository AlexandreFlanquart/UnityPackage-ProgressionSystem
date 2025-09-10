using MyUnityPackage.Toolkit;
using UnityEngine;
using System.Collections.Generic;


namespace MyUnityPackage.ProgressionSystem
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private Transform questsContainer;
        
        private Dictionary<string, Quest> questDataDict = new Dictionary<string, Quest>();
        private Transform questTemplate;
        
        void Awake()
        {
            questTemplate = questsContainer.transform.GetChild(0);

            // Load all ScriptableObjects of type QuestDataSO from Resources folder
            var questDatas = Resources.LoadAll<QuestDataSO>("Quest/QuestSO");
            MUPLogger.LogMessage(questDatas.Length + " QuestDataSO loaded");

            // Fill the dictionary
            Quest questTemp = null;
            foreach (var data in questDatas)
            {
                if (!questDataDict.ContainsKey(data.id))
                {
                    questTemp =  data.CreateRuntimeQuest();
                    questDataDict.Add(data.id, questTemp);
                    MUPLogger.LogMessage(data.id + " loaded");

                    // Instatiate the questUI
                    Transform questTransform = Instantiate(questTemplate, questsContainer);
                    questTransform.gameObject.SetActive(true);
                    questTransform.gameObject.GetComponent<QuestUI>().Setup(questTemp);
                }
            }
           // ActivateQuest("Quest1");
        }

        public Quest GetQuestDataByName(string questName)
        {
            if(!questDataDict.TryGetValue(questName, out var quest))
            {
                MUPLogger.LogMessageError("quest : " + questName + " not found");
                return null;
            }
            return quest;
        }

        public void ActivateQuest(string questId)
        {
            var quest = GetQuestDataByName(questId);
            if (quest != null)
            {
                quest.Active(true); 
            }
            else
            {
                Debug.LogWarning($"Quest with id {questId} not found.");
            }
        }

    }
}