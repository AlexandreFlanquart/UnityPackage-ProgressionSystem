using System;

namespace MyUnityPackage.ProgressionSystem
{
    public interface IProgressionNotifier
    {
        event Action<int, int> OnProgress;
    }
}
