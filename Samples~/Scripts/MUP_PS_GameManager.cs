using UnityEngine;
using MyUnityPackage.ProgressionSystem;
public class MUP_PS_GameManager : MonoBehaviour
{
    [SerializeField] QuestManager questManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questManager.ActivateQuest("Quest1");
    }

}
