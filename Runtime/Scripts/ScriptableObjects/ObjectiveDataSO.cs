using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public abstract class ObjectiveDataSO : ScriptableObject
    {
        public string title;
        [TextArea] public string description;

        public abstract IQuestObjective CreateRuntimeObjective();

    }
}
