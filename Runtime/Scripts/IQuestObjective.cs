
namespace MyUnityPackage.Quests
{
    public interface IQuestObjective
    {
        string Title { get; }
        string Description { get; }
        string Count { get; }
        bool IsComplete { get; }
        int CurrentProgress { get; }
        int MaxProgress { get; }

        void Start();
    }
}

