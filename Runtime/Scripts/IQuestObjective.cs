using System;

namespace MyUnityPackage.ProgressionSystem
{
    public interface IQuestObjective
    {
        string Title { get; }
        string Description { get; }
        bool IsCompleted { get; }
        int CurrentProgression { get; }
        int MaxProgression { get; }
         public event Action OnCompleted;

        void Start();
    }
}

