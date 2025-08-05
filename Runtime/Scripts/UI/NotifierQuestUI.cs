using System.Collections.Generic;
using MyUnityPackage.Toolkit;
using TMPro;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public class NotifierQuestUI : MonoBehaviour
    {        
            public TextMeshProUGUI titleText;
            public TextMeshProUGUI descriptionText;
        
            public void Setup(Quest quest)
            {
                MyUnityPackage.Toolkit.Logger.LogMessage("Setup NotifierQuestUI - " + " id : " + quest.id + " title : " + quest.title);
                titleText.text = quest.title;
                descriptionText.text = quest.description;              
            }
    }
}