using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;

public class KillObjective : ObjectiveBase
{

    public KillObjective(string title, string description, int countRequired): base(title, description, countRequired)
    {
    }
    
    public override void Start()
    {
        MUPLogger.Info("KillObjective started ! ");
        Monster.OnAnyKill += OnProgressChanged;
    }
    
    public override void Stop(){
        Monster.OnAnyKill -= OnProgressChanged;
    }



}
    
