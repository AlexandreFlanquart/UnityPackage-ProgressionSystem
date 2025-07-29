using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using System;

public class CoinObjective : IQuestObjective, IProgressionNotifier
{
    private string title;
    public string Title => title;
    private string description; 
    public string Description => description;

    private bool isCompleted;
    public bool IsCompleted => isCompleted;

    private int currentProgress;
    public int CurrentProgress => currentProgress;

    private int maxProgress;
    public int MaxProgress => maxProgress;

    public event Action<int, int> OnProgress;
    public event Action OnCompleted;

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
        if(isCompleted) return;

        Logger.LogMessage("CoinObjective : OnCoinClaim");
        currentProgress++;
        Logger.LogMessage("currentProgress : " + currentProgress);

        if (CheckProgress())
        {
            OnCompleted?.Invoke();
            Logger.LogMessage("OnCompleted : ");
        }
        OnProgress?.Invoke(currentProgress, MaxProgress);
    }

    public bool CheckProgress()
    {
        return isCompleted = CurrentProgress >= MaxProgress;
    }

    public bool IsComplete()
    {
        return IsCompleted;
    }
}
