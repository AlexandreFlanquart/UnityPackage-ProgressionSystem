using System;

namespace MyUnityPackage.ProgressionSystem
{
    public interface IQuestObjective
    {
        string Title { get; }
        string Description { get; }
        string Count { get; }
        bool IsCompleted { get; }
        int CurrentProgress { get; }
        int MaxProgress { get; }
         public event Action OnCompleted;

        void Start();
    }
}

