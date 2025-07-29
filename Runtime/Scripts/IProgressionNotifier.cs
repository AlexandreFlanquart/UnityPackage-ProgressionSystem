using System;

namespace MyUnityPackage.Quests
{
    public interface IProgressionNotifier
    {
        event Action<int, int> OnProgress;
    }
}
