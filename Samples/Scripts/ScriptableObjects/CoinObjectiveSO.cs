using MyUnityPackage.Quests;

public class CoinObjectiveSO : ObjectiveDataSO
{
    public int countRequired;

    public override IQuestObjective CreateRuntimeObjective()
    {
        return new CoinObjective("Coin title", "Coin description", countRequired);
    }
}
