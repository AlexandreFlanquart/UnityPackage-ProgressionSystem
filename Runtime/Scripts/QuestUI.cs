using UnityEngine;
using TMPro;
using System.Collections.Generic;
using MyUnityPackage.Toolkit;
 

namespace MyUnityPackage.ProgressionSystem
{
    public class QuestUI : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI countText;

        public Transform objectivesContainer;
        public GameObject objectivePrefab;

        private List<TextMeshProUGUI> objectiveTexts = new List<TextMeshProUGUI>();

        void Awake()
        {
            ServiceLocator.AddService<QuestUI>(gameObject);
        }

        public void Setup(Quest quest)
        {
            MyUnityPackage.Toolkit.Logger.LogMessage("Setup : " + quest.id);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            countText.text = "0 / " +  quest.objectives.Count;

            foreach (var objective in quest.objectives)
            {
                var objectiveGO = Instantiate(objectivePrefab, objectivesContainer);
                objectiveGO.SetActive(true);
                var objectiveUI = objectiveGO.GetComponent<ObjectiveUI>();
                objectiveUI.Setup(objective.Title, objective.Description, objective.MaxProgress);
                if (objective is IQuestObjective coinObj)
                {
                    MyUnityPackage.Toolkit.Logger.LogMessage("coinObj.OnCompleted : ");
                     quest.OnQuestProgress();
                    coinObj.OnCompleted += () => { 
                        MyUnityPackage.Toolkit.Logger.LogMessage("OnCompleted : ");
                        SetCount(quest.currentProgression, quest.maxProgression);
                    };
                }

                if (objective is IProgressionNotifier notifier)
                {
                    MyUnityPackage.Toolkit.Logger.LogMessage("notifier.OnProgres : ");
                    notifier.OnProgress += (current, total) =>
                    {           
                        MyUnityPackage.Toolkit.Logger.LogMessage("OnProgress : ");
                        objectiveUI.SetCount(current, total);
                    };
                }
            }
        }

        public void SetCount(int count, int max)
        {
            countText.text = count + " / " + max;
        }
    }
}