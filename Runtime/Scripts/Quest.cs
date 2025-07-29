using MyUnityPackage.Toolkit;
using System;
using System.Collections.Generic;

namespace MyUnityPackage.ProgressionSystem
{
    public class Quest
    {
        public string id;
        public string title;
        public string description;
        public int currentProgression;
        public int maxProgression;
        public List<IQuestObjective> objectives;
        public bool isCompleted = false; 
        public bool isActive = false;

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public Quest(string _id, string _title, string _description, List<IQuestObjective> _objectives)
        {
            id = _id;
            title = _title;
            description = _description;
            objectives = _objectives;
            maxProgression = _objectives.Count;
        }

        public void Active(bool _active){
            MyUnityPackage.Toolkit.Logger.LogMessage("active : " + _active + " on " + id);
            isActive = _active;
            if(isActive){
                foreach(var objective in objectives){
                    objective.Start();
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

        public void OnQuestProgress(){
            if(isCompleted) return;
        
            Logger.LogMessage("quest : OnProgress");
            currentProgression++;
            Logger.LogMessage("currentProgress : " + currentProgression);

            if (CheckProgress())
            {
                OnCompleted?.Invoke();
                Logger.LogMessage("OnCompleted : ");
            }
            OnProgress?.Invoke(currentProgression, maxProgression);
        }


    }
}