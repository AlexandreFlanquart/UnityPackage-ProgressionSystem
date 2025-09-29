using System;

namespace MyUnityPackage.ProgressionSystem
{
    public interface IQuestObjective
    {
        public string Title { get; }
        public string Description { get; }
        public bool IsCompleted { get; }
        public int CurrentProgression { get; }
        public int MaxProgression { get; }
        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        void Start();
        void Stop();
    }
}

