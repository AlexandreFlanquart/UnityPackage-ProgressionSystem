using TMPro;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem{
    /// <summary>
    /// ExtendedQuestUI is a UI component that displays more information about a quest when mouse is over the quest. 
    /// It is used to display the quest title, description and current progression.
    /// It is also used to display the objectives and rewards of the quest.
    /// </summary>
    public class ExtendedQuestUI : MonoBehaviour
    {
            [Header("Head")]
            [SerializeField] private TextMeshProUGUI titleHead;
            [SerializeField] private TextMeshProUGUI descriptionHead;
            [SerializeField] private TextMeshProUGUI stepCount;

            [Header("Objective")]
            [SerializeField] private GameObject objectiveTemplate;
            [SerializeField] private Transform objectiveContainer;

            [Header("Rewards")]
            [SerializeField] private Transform rewardsContainer;
            [SerializeField] private GameObject rewardTemplate;

            public void Setup(Quest quest){
                titleHead.text = quest.title;
                descriptionHead.text = quest.description;
                stepCount.text = quest.currentProgression.ToString() + "/" + quest.maxProgression.ToString();
                
                for(int i = objectiveContainer.childCount - 1; i > 0; i--) {
                    DestroyImmediate(objectiveContainer.GetChild(i).gameObject);
                }
                
                foreach (var objective in quest.steps[quest.currentProgression].objectives){
                    var objectiveGO = Instantiate(objectiveTemplate, objectiveContainer);
                    objectiveGO.SetActive(true);
                    var objectiveUI = objectiveGO.GetComponent<ObjectiveUI>();
                    objectiveUI.Setup(objective);
                }

                //TO DO : Instantiate rewards
            }

}
}
