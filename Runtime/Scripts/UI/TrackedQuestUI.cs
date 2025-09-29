using UnityEngine;
using TMPro;
using Codice.Client.BaseCommands;

namespace MyUnityPackage.ProgressionSystem
{
    public class TrackedQuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI progressionText;

        private Quest trackedQuest;

        public void Show()
        {
            gameObject.SetActive(true);
            if (trackedQuest != null)
            {
                trackedQuest.OnProgressionChanged += UpdateProgression;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            if (trackedQuest != null)
            {
                trackedQuest.OnProgressionChanged -= UpdateProgression;
            }
        }

        public void Setup(Quest quest)
        {
            trackedQuest = quest;
            if (titleText != null)
                titleText.text = quest.title;
            if (descriptionText != null)
                descriptionText.text = quest.description;
            if (progressionText != null)
                progressionText.text = $"{quest.currentProgression} / {quest.maxProgression}";
        }

        private void UpdateProgression()
        {
            if (trackedQuest != null && progressionText != null)
            {
                progressionText.text = $"{trackedQuest.currentProgression} / {trackedQuest.maxProgression}";
            }
        }
    }   
}

