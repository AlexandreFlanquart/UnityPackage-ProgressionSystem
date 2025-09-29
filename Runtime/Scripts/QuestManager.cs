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

        private NotifierQuestUI notifierQuestUI;
        private ExtendedQuestUI extentedUI;
        private TrackedQuestUI trackedQuestUI;

        void Awake()
        {
            ServiceLocator.AddService<QuestManager>(gameObject);
        }

        public void Init()
        {
            notifierQuestUI = ServiceLocator.GetService<NotifierQuestUI>();
            extentedUI = ServiceLocator.GetService<ExtendedQuestUI>();
            trackedQuestUI = ServiceLocator.GetService<TrackedQuestUI>();

            questTemplate = questsContainer.transform.GetChild(0);

            // Load all ScriptableObjects of type QuestDataSO from Resources folder
            var questDatas = Resources.LoadAll<QuestDataSO>("Quest/QuestSO");
            MUPLogger.Info(questDatas.Length + " QuestDataSO loaded");

            // Fill the dictionary
            Quest questTemp = null;
            foreach (var data in questDatas)
            {
                questTemp = data.CreateRuntimeQuest();
                if (!questDataDict.ContainsKey(questTemp.id))
                {
                    questTemp = data.CreateRuntimeQuest();
                    questDataDict.Add(questTemp.id, questTemp);
                    MUPLogger.Info(questTemp.id + " loaded");

                    // Instatiate the questUI
                    Transform questTransform = Instantiate(questTemplate, questsContainer);
                    questTransform.gameObject.SetActive(true);
                    questTransform.gameObject.GetComponent<QuestUI>().Setup(questTemp);
                }
            }
        }

        public Quest GetQuestDataByID(string questID)
        {
            if (!questDataDict.TryGetValue(questID, out var quest))
            {
                MUPLogger.Error("quest : " + questID + " not found");
                return null;
            }
            return quest;
        }

        public void ActivateQuest(string questID)
        {
            var quest = GetQuestDataByID(questID);
            if (quest != null)
            {
                quest.Active(true);
            }
            else
            {
                Debug.LogWarning($"Quest with id {questID} not found.");
            }
            notifierQuestUI.Setup(quest);
            notifierQuestUI.Show();
        }

        public void TrackQuest(Quest quest, bool track = true)
        {
            if (quest == null) return;

            quest.Track(track);
            if (!track)
            {
                trackedQuestUI.Hide();
                return;
            }

            MUPLogger.Info("Tracking quest: " + quest.id);
        
            trackedQuestUI.Setup(quest);
            trackedQuestUI.Show();
        }

        public void ShowExtendedQuestUI(Quest quest)
        {
            extentedUI.Setup(quest);
            extentedUI.Show();
        }

        public void HideExtendedQuestUI()
        {
            extentedUI.Hide();
        }

    }
}