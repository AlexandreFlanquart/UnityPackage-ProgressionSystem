using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace MyUnityPackage.ProgressionSystem
{
    /// <summary>
    /// QuestUI is a UI component that displays a quest in the list of quests. 
    /// It is used to display the quest title, description and current progression.
    /// It is also used to update the current progression when the quest is completed.
    /// </summary>
    public class QuestUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI progressionText;
        [SerializeField] private GameObject extentedUIGO;

        private ExtendedQuestUI extentedUI;
        private Quest quest;
        private bool isActive = true;

        public void Start(){
            extentedUI = extentedUIGO.GetComponent<ExtendedQuestUI>();
        }

        public void Setup(Quest _quest)
        {
            quest = _quest;
            MyUnityPackage.Toolkit.Logger.LogMessage("Setup QuestUI - " + " id : " +  quest.id + " title : " + quest.title);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            progressionText.text = quest.currentProgression + " / " + quest.maxProgression;  
            quest.OnProgress += UpdateQuestUI;
            quest.OnCompleted += delegate {isActive = false;};
        }

        public void UpdateQuestUI(int current, int max)
        {      
            MyUnityPackage.Toolkit.Logger.LogMessage("UpdateQuestUI - " + " current : " + current + " max : " + max);
            progressionText.text = current + " / " + max;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {   
            if(!isActive)return;

            if (extentedUI != null)
            {
                extentedUI.Setup(quest);
                extentedUIGO.SetActive(true);
                MyUnityPackage.Toolkit.Logger.LogMessage("Mouse hover QuestUI");
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(!isActive)return;

            if (extentedUI != null)
            {
                extentedUIGO.SetActive(false);
                MyUnityPackage.Toolkit.Logger.LogMessage("Mouse leave QuestUI");
            }
        }
    }
}