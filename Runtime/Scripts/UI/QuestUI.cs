using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using MyUnityPackage.Toolkit;

namespace MyUnityPackage.ProgressionSystem
{
    /// <summary>
    /// QuestUI is a UI component that displays a quest in the list of quests. 
    /// It is used to display the quest title, description and current progression.
    /// It is also used to update the current progression when the quest is completed.
    /// </summary>
    public class QuestUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI progressionText;
        [SerializeField] private GameObject lockImage;
        [SerializeField] private GameObject trackImage;


        private Quest quest;
        private bool isActive = true;
        private bool isTracked = false;

        private QuestManager questManager;

        void Start()
        {
            questManager = ServiceLocator.GetService<QuestManager>();
        }

        public void Setup(Quest _quest)
        {
            quest = _quest;
            MUPLogger.Info("Setup QuestUI - " + " id : " + quest.id + " title : " + quest.title);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            progressionText.text = quest.currentProgression + " / " + quest.maxProgression;
            quest.OnStarted += delegate { SetActive(true); };
            quest.OnProgressionChanged += UpdateQuestUI;
            quest.OnCompleted += delegate { SetActive(false);  questManager.TrackQuest(quest, false);};
            SetActive(false);
        }

        public void UpdateQuestUI()
        {
            MUPLogger.Info("UpdateQuestUI - " + " current : " + quest.currentProgression + " max : " + quest.maxProgression);
            progressionText.text = quest.currentProgression + " / " + quest.maxProgression;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isActive) return;

            MUPLogger.Info("Mouse hover QuestUI");
            questManager.ShowExtendedQuestUI(quest);   
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!isActive) return;

            MUPLogger.Info("Mouse leave QuestUI");
            questManager.HideExtendedQuestUI();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isActive) return;

            isTracked = !isTracked;
            questManager.TrackQuest(quest, isTracked);
            trackImage.SetActive(isTracked);
            MUPLogger.Info("Mouse click QuestUI");
        }

        public void SetActive(bool active)
        {
            isActive = active;
            lockImage.SetActive(!active);
        }
    }
}