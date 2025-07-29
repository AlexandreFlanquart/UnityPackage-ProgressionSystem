using MyUnityPackage.Quests;
using System;

public class CoinObjective : IQuestObjective, IProgressionNotifier
{
    private string title;
    public string Title => title;
    private string description; 
    public string Description => description;

    private bool isComplete;
    public bool IsComplete => isComplete;

    private int currentProgress;
    public int CurrentProgress => currentProgress;

    private int maxProgress;

    public event Action<int, int> OnProgress;

    public int MaxProgress => maxProgress;

    public string Count => throw new NotImplementedException();

    public CoinObjective(string _title, string _description, int _countRequired)
    {
        title = _title;
        description = _description;
        currentProgress = 0;
        maxProgress = _countRequired;
    }

    public void Start()
    {
        Coin.OnAnyCoinsclaim += OnCoinClaim;
    }

    public void OnCoinClaim()
    {
        currentProgress++;
        if (CheckProgress())
        {
            //TO DO
        }
        OnProgress?.Invoke(currentProgress, MaxProgress);
    }

    public bool CheckProgress()
    {
        return isComplete = CurrentProgress >= MaxProgress;
    }

    public bool IsProgress()
    {
        return IsComplete;
    }
}
