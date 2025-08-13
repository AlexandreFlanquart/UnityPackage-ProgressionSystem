using UnityEngine;
using MyUnityPackage.ProgressionSystem;

[CreateAssetMenu(fileName = "KillObjectiveSO", menuName = "ScriptableObjects/Quest/KillObjectiveSO")]
public class KillObjectiveSO : ObjectiveDataSO
{
    public int countRequired;

    public override IQuestObjective CreateRuntimeObjective()
    {
        return new KillObjective("kill title", "kill description", countRequired);
    }
}
