using MyUnityPackage.Quests;
using UnityEngine;

namespace MyUnityPackage.Quests
{
    [CreateAssetMenu(fileName = "ObjectiveDataSO", menuName = "ScriptableObjects/Quest/ObjectiveDataSO")]

    public abstract class ObjectiveDataSO : ScriptableObject
    {
        public string title;
        [TextArea] public string description;

        public abstract IQuestObjective CreateRuntimeObjective();

    }
}
