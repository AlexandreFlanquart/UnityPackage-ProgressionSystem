using System.Collections.Generic;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public class QuestStep : MonoBehaviour
    {
        public List<IQuestObjective> objectives;

        public QuestStep(List<IQuestObjective> _objectives)
        {
            objectives = _objectives;
        }

        public void Start()
        {
            foreach (var objective in objectives)
                objective.Start();
        }
    }
}