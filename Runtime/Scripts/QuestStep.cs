using System;
using System.Collections.Generic;
using MyUnityPackage.Toolkit;

namespace MyUnityPackage.ProgressionSystem
{
    public class QuestStep : IProgressionNotifier
    {
        public List<IQuestObjective> objectives;
        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        private int currentProgression;
        private int maxProgression;   
        private bool isCompleted;

        public QuestStep(List<IQuestObjective> _objectives)
        {
            objectives = _objectives;
            currentProgression = 0;
            maxProgression = _objectives.Count;
            foreach (IQuestObjective _objective in objectives){
                _objective.OnCompleted += OnProgressChange;
            }
        }

        public void Start()
        {
            Logger.LogMessage("QuestStep : Start");
            foreach (var objective in objectives)
                objective.Start();
        }

        public void Stop()
        {
            Logger.LogMessage("QuestStep : Stop");
            foreach (var objective in objectives)
                objective.Start();
        }

        public void OnProgressChange(){
            if(isCompleted) return;

            Logger.LogMessage("QuestStep - OnProgressChange");
            currentProgression++;
            Logger.LogMessage("QuestStep - currentProgress : " + currentProgression);
            OnProgress?.Invoke(currentProgression, maxProgression);

            if (CheckProgression())
            {
                OnCompleted?.Invoke();
                Logger.LogMessage("QuestStep - OnCompleted");
            }
        }

        public bool CheckProgression()
        {
            return isCompleted = currentProgression >= maxProgression;
        }
    }
}