using MyUnityPackage.Toolkit;
using System;
using System.Collections.Generic;

namespace MyUnityPackage.ProgressionSystem
{
    /// <summary>
    /// Quest is a class that represents a quest.
    /// It contains the quest id, title, description, current progression, max progression, objectives, is completed and is active.
    /// It also contains the events for the quest progression and completion.
    /// </summary>
    public class Quest
    {
        public readonly string id;
        public readonly string title;
        public readonly string description;
        public int currentProgression { get; private set; }
        public int maxProgression { get; private set; }
        public List<QuestStep> steps { get; private set; }
        public bool isCompleted => currentProgression >= maxProgression;
        public bool isActive { get; private set; } = false;
        public bool isTracked { get; private set; } = false;

        public event Action OnProgressionChanged;
        public event Action OnStarted;
        public event Action OnCompleted;


        public Quest(string _id, string _title, string _description, List<QuestStep> _steps)
        {
            id = _id;
            title = _title;
            description = _description;
            steps = _steps;
            maxProgression = _steps.Count;
            foreach (QuestStep step in steps)
            {
                step.OnCompleted += OnProgressChange;
            }
        }

        public void Active(bool _active)
        {
            MUPLogger.Info("active : " + _active + " on " + id);
            isActive = _active;
            if (isActive)
            {
                steps[currentProgression].Start();
            }
            OnStarted?.Invoke();
        }

        private void OnProgressChange()
        {
            if (isCompleted) return;

            MUPLogger.Info("quest : OnProgress");
            currentProgression++;
            MUPLogger.Info("currentProgress : " + currentProgression);
            OnProgressionChanged?.Invoke();

            if (isCompleted)
            {
                OnCompleted?.Invoke();
                MUPLogger.Info("Quest : " + id + " Completed !");
            }
            else
                steps[currentProgression].Start();
        }

        public void Track(bool _track)
        {
            isTracked = _track;
            MUPLogger.Info("track : " + _track + " on " + id);
        }

    }
}