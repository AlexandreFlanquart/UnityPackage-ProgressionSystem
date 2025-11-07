using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using MyUnityPackage.Toolkit;
using TMPro;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public class NotifierQuestUI : MonoBehaviour
    {
        struct NotifUI
        {
            public string title;
            public string description;
            public NotifUI(string title, string description)
            {
                this.title = title;
                this.description = description;
            }
        }
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private float hideAfterDelay = 3f;
        [SerializeField] private float timeBetweenQueue = 2f;
        Queue<NotifUI> notifUIQueue = new Queue<NotifUI>();
        bool isRunning = false;
        GameObject content;
        void Awake()
        {
            content = transform.GetChild(0).gameObject;   
        }


        public void SetupAndShow(Quest quest)
        {
            //Add to queue
            MUPLogger.Info("Setup Add to Queue NotifierQuestUI - " + " id : " + quest.id + " title : " + quest.title);
            NotifUI notifUI = new NotifUI(quest.title, quest.description);
            notifUIQueue.Enqueue(notifUI);
            
            if(isRunning)
                return;
            //Init state 
            isRunning = true;
            gameObject.SetActive(true);
            content.SetActive(true);
            StartCoroutine(HideAfterDelay(hideAfterDelay));
        }

        public void Hide()
        {
            isRunning = false;
            content.SetActive(false);
            gameObject.SetActive(false);
        }

        private IEnumerator HideAfterDelay(float delay)
        {
            //MUPLogger.Info("Begin coroutine" +notifUIQueue.Count );

            while(notifUIQueue.Count>0)
            {
                //MUPLogger.Info("Dequee");
                NotifUI notifUI = notifUIQueue.Dequeue();
                titleText.text = notifUI.title;
                descriptionText.text = notifUI.description;
                content.SetActive(true);  

                yield return new WaitForSeconds(delay);
                content.SetActive(false);
                yield return new WaitForSeconds(timeBetweenQueue);
                
            }

            Hide();
        }

    }
}