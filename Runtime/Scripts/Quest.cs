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
        public string id {get; private set;}
        public string title {get; private set;}
        public string description {get; private set;}
        public int currentProgression {get; private set;}
        public int maxProgression {get; private set;}
        public List<QuestStep> steps;
        public bool isCompleted {get; private set;} = false; 
        public bool isActive {get; private set;} = false;

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public Quest(string _id, string _title, string _description, List<QuestStep> _steps)
        {
            id = _id;
            title = _title;
            description = _description;
            steps = _steps;
            maxProgression = _steps.Count;
            foreach (QuestStep step in steps){
                step.OnCompleted += OnProgressChange;
            }
        }

        public void Active(bool _active){
            MyUnityPackage.Toolkit.Logger.LogMessage("active : " + _active + " on " + id);
            isActive = _active;
            if(isActive){
                foreach(var step in steps){
                    step.Start();
                }
            }
        }

        public bool IsActive(){
            return isActive;
        }

        public void Completed(bool _completed){
            isCompleted = _completed;
        }
        public bool IsCompleted(){
            return isCompleted;
        }

        public bool CheckProgress()
        {
            return isCompleted = currentProgression >= maxProgression;
        }

        public void OnProgressChange(){
            if(isCompleted) return;
        
            Logger.LogMessage("quest : OnProgress");
            currentProgression++;
            Logger.LogMessage("currentProgress : " + currentProgression);
            OnProgress?.Invoke(currentProgression, maxProgression);

            if (CheckProgress())
            {
                OnCompleted?.Invoke();
                Logger.LogMessage("OnCompleted : ");
            }
        }


    }
}