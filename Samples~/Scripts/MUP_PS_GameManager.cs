using UnityEngine;
using MyUnityPackage.ProgressionSystem;

public class MUP_PS_GameManager : MonoBehaviour
{
    [SerializeField] QuestManager questManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questManager.Init();
        questManager.ActivateQuest("Quest1");
        questManager.GetQuestDataByID("Quest1").OnCompleted += delegate { questManager.ActivateQuest("Quest2"); questManager.ActivateQuest("Quest3");};
    }

}
