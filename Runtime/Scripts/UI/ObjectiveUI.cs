using TMPro;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public class ObjectiveUI : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI countText;

        public void Setup(IQuestObjective objective)
        {
            titleText.text = objective.Title;
            descriptionText.text = objective.Description;
            countText.text = objective.CurrentProgression + " / " + objective.MaxProgression;
            objective.OnProgress += UpdateProgression;
        }

        public void UpdateProgression(int count, int max)
        {
            countText.text = count + " / " + max;
        }
    }
}