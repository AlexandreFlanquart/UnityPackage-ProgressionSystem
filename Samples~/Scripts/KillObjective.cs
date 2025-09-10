using System;
using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;

public class KillObjective : IQuestObjective, IProgressionNotifier
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
    public KillObjective(string _title, string _description, int _countRequired)
    {
        title = _title;
        description = _description;
        currentProgress = 0;
        maxProgress = _countRequired;
    }
    public void Start()
    {
        MUPLogger.LogMessage("KillObjective started ! " );
        Monster.OnAnyKill += OnProgressChange;
    }
    
    public void Stop(){
         Monster.OnAnyKill -= OnProgressChange;
    }

    public void OnProgressChange()
    {
        if(isCompleted) return;

        MUPLogger.LogMessage("KillObjective : OnMonsterKill");
        currentProgress++;
        MUPLogger.LogMessage("currentProgress : " + currentProgress);

        if (CheckProgress())
        {
            OnCompleted?.Invoke();
            MUPLogger.LogMessage("OnCompleted : ");
        }
        OnProgress?.Invoke(currentProgress, MaxProgression);
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
    
