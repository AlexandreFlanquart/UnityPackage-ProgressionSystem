using MyUnityPackage.ProgressionSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinObjectiveSO", menuName = "ScriptableObjects/Quest/CoinObjectiveSO")]
public class CoinObjectiveSO : ObjectiveDataSO
{
    public int countRequired;

    public override IQuestObjective CreateRuntimeObjective()
    {
        return new CoinObjective("Coin title", "Coin description", countRequired);
    }
}
