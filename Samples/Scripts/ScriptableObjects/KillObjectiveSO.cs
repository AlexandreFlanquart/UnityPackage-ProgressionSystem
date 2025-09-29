using UnityEngine;
using MyUnityPackage.ProgressionSystem;

[CreateAssetMenu(fileName = "KillObjectiveSO", menuName = "ScriptableObjects/Quest/KillObjectiveSO")]
public class KillObjectiveSO : ObjectiveDataSO
{
    [SerializeField] private int countRequired;

    public override IQuestObjective CreateRuntimeObjective()
    {
        return new KillObjective(Title, Description, countRequired);
    }
}
