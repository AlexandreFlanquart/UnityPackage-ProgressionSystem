using System;
using MyUnityPackage.Toolkit;

namespace MyUnityPackage.ProgressionSystem
{
    public abstract class ObjectiveBase : IQuestObjective
    {
        public string Title { get; }
        public string Description { get; }

        public int MaxProgression { get; }
        public int CurrentProgression { get; protected set; }
        public bool IsCompleted => CurrentProgression >= MaxProgression;

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        protected ObjectiveBase(string title, string description, int maxProgression)
        {
            Title = title;
            Description = description;
            MaxProgression = Math.Max(1, maxProgression);
            CurrentProgression = 0;
        }

        public abstract void Start();
        public abstract void Stop();

        protected void AddProgress(int amount)
        {
            if (IsCompleted || amount <= 0)
                return;

            CurrentProgression = Math.Min(MaxProgression, CurrentProgression + amount);
            OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (IsCompleted)
                OnCompleted?.Invoke();
        }

        protected void SetProgress(int value)
        {
            int clamped = Math.Clamp(value, 0, MaxProgression);
            if (CurrentProgression == clamped || IsCompleted)
                return;

            CurrentProgression = clamped;
            OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (IsCompleted)
                OnCompleted?.Invoke();
        }

        protected virtual void OnProgressChanged()
        {
            AddProgress(1);
        }


    }
}
