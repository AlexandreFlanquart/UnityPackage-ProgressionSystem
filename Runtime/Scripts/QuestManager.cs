using MyUnityPackage.Quests;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestUI questUI;

    void Start()
    {
        // Get quest SO


        /*
        foreach (var data in questDatas)
        {
            var quest = data.CreateRuntimeQuest();
            quest.StartQuest();
            questUI.Setup(quest); // ⚠️ c’est ici qu’on connecte la quête à l’UI
        }
        */
    }
}
