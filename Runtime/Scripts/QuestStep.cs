using System;
using System.Collections.Generic;
using MyUnityPackage.Toolkit;

namespace MyUnityPackage.ProgressionSystem
{
    public class QuestStep
    {
        public int currentProgression {get; private set;}
        public int maxProgression {get; private set;} 
        public bool isCompleted => currentProgression >= maxProgression;

        public List<IQuestObjective> objectives { get; private set; }
        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

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
            MUPLogger.Info("QuestStep : Start");
            foreach (var objective in objectives)
                objective.Start();
        }

        public void Stop()
        {
            MUPLogger.Info("QuestStep : Stop");
            foreach (var objective in objectives)
                objective.Stop();
        }

        private void OnProgressChange(){
            if(isCompleted) return;

            MUPLogger.Info("QuestStep - OnProgressChange");
            currentProgression++;
            MUPLogger.Info("QuestStep - currentProgress : " + currentProgression);
            OnProgress?.Invoke(currentProgression, maxProgression);

            if (isCompleted)
            {
                OnCompleted?.Invoke();
                MUPLogger.Info("QuestStep - OnCompleted");
            }
        }
    }
}