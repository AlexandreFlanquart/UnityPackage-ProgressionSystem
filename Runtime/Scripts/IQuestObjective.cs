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
        event Action<int, int> OnProgress;
        public event Action OnCompleted;

        void Start();
        void Stop();
        bool CheckProgress();
        bool IsComplete();
        void OnProgressChange();
    }
}

