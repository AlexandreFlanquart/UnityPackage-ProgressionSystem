using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public abstract class ObjectiveDataSO : ScriptableObject
    {
        [SerializeField] private string title;
        public string Title => title;
        [TextArea][SerializeField] private string description;
        public string Description => description;

        public abstract IQuestObjective CreateRuntimeObjective();

    }
}
