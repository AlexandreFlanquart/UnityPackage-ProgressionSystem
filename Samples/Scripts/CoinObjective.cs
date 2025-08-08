using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using System;

public class CoinObjective : IQuestObjective
{
    private string title;
    public string Title => title;
    private string description; 
    public string Description => description;

    private bool isCompleted;
    public bool IsCompleted => isCompleted;

    private int currentProgress;
    public int CurrentProgression => currentProgress;

    private int maxProgress;
    public int MaxProgression => maxProgress;

    public event Action<int, int> OnProgress;
    public event Action OnCompleted;

    public CoinObjective(string _title, string _description, int _countRequired)
    {
        title = _title;
        description = _description;
        currentProgress = 0;
        maxProgress = _countRequired;
    }

    public void Start()
    {
        MyUnityPackage.Toolkit.Logger.LogMessage("CoinObjective started ! " );
        Coin.OnAnyCoinsclaim += OnProgressChange;
    }

    public void Stop()
    {
        Coin.OnAnyCoinsclaim -= OnProgressChange;
    }

    public void OnProgressChange()
    {
        if(isCompleted) return;

        Logger.LogMessage("CoinObjective - OnCoinClaim");
        currentProgress++;
        Logger.LogMessage("CoinObjective - currentProgress : " + currentProgress);
        OnProgress?.Invoke(currentProgress, MaxProgression);

        if (CheckProgress())
        {
            OnCompleted?.Invoke();
            Logger.LogMessage("CoinObjective - OnCompleted : ");
        }
    }

    public bool CheckProgress()
    {
        return isCompleted = CurrentProgression >= MaxProgression;
    }

    public bool IsComplete()
    {
        return IsCompleted;
    }
}
