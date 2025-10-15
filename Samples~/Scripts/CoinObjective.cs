using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using System;

public class CoinObjective : ObjectiveBase
{

    public CoinObjective(string title, string description, int countRequired): base(title, description, countRequired)
    {

    }

    public override void Start()
    {
        MUPLogger.Info("CoinObjective started ! ");
        Coin.OnAnyCoinsclaim += OnProgressChanged;
    }

    public override void Stop()
    {
        Coin.OnAnyCoinsclaim -= OnProgressChanged;
    }

}
