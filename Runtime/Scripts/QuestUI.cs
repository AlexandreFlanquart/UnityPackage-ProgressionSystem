using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace MyUnityPackage.Quests
{
    public class QuestUI : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;

        public Transform objectivesContainer;
        public GameObject objectivePrefab;

        private List<TextMeshProUGUI> objectiveTexts = new List<TextMeshProUGUI>();

        public void Setup(Quest quest)
        {
            titleText.text = quest.Title;

            foreach (var objective in quest.Objectives)
            {
                var objectiveGO = Instantiate(objectivePrefab, objectivesContainer);
                var objectiveUI = objectiveGO.GetComponent<ObjectiveUI>();
                objectiveUI.Setup(objective.Title, objective.Description, objective.Count);

                // Écoute des changements de progression (si l’objectif expose un event)
                if (objective is IProgressionNotifier notifier)
                {
                    notifier.OnProgress += (current, total) =>
                    {
                        objectiveUI.SetCount(current, total);
                    };
                }
            }
        }
    }
}