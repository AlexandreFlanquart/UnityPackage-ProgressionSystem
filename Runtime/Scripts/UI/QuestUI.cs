using UnityEngine;
using TMPro;

namespace MyUnityPackage.ProgressionSystem
{
    /// <summary>
    /// QuestUI is a UI component that displays a quest in the list of quests. 
    /// It is used to display the quest title, description and current progression.
    /// It is also used to update the current progression when the quest is completed.
    /// </summary>
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI progressionText;

        public void Setup(Quest quest)
        {
            MyUnityPackage.Toolkit.Logger.LogMessage("Setup QuestUI - " + " id : " +  quest.id + " title : " + quest.title);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            progressionText.text = quest.currentProgression + " / " + quest.maxProgression;  
        }

        public void UpdateProgression(int current, int max)
        {      
            MyUnityPackage.Toolkit.Logger.LogMessage("UpdateProgression QuestUI - " + " current : " + current + " max : " + max);
            progressionText.text = current + " / " + max;
        }
    }
}