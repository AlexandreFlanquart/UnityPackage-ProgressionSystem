using MyUnityPackage.ProgressionSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinObjectiveSO", menuName = "ScriptableObjects/Quest/CoinObjectiveSO")]
public class CoinObjectiveSO : ObjectiveDataSO
{
    [SerializeField] private int countRequired;

    public override IQuestObjective CreateRuntimeObjective()
    {
        return new CoinObjective(Title, Description, countRequired);
    }
}
