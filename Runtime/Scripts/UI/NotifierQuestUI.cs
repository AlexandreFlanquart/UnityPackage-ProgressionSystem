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
        bool isShow = false;
        GameObject content;
        void Awake()
        {
            content = transform.GetChild(0).gameObject;   
        }
        public void Setup(Quest quest)
        {
            if(isShow)
            {
                MUPLogger.Info("Setup Add to Queue NotifierQuestUI - " + " id : " + quest.id + " title : " + quest.title);
                NotifUI notifUI = new NotifUI(quest.title, quest.description);
                notifUIQueue.Enqueue(notifUI);
            }
            else
            {
                MUPLogger.Info("Setup NotifierQuestUI - " + " id : " + quest.id + " title : " + quest.title);
                titleText.text = quest.title;
                descriptionText.text = quest.description;
                StopAllCoroutines();
            }
            
        }

        public void Show()
        {
            if(isShow)
                return;
            isShow = true;
            gameObject.SetActive(true);
            content.SetActive(true);
            StartCoroutine(HideAfterDelay(hideAfterDelay));
        }
        
        public void Hide()
        {
            isShow = false;
            content.SetActive(false);
            gameObject.SetActive(false);
        }

        private IEnumerator HideAfterDelay(float delay)
        {
            MUPLogger.Info("Begin coroutine" +notifUIQueue.Count );
            
            yield return new WaitForSeconds(delay);
        
            while(notifUIQueue.Count>0)
            {
                content.SetActive(false);
                yield return new WaitForSeconds(timeBetweenQueue);

                NotifUI notifUI = notifUIQueue.Dequeue();
                titleText.text = notifUI.title;
                descriptionText.text = notifUI.description;
                content.SetActive(true);  
            }
            yield return new WaitForSeconds(delay);
            
            Hide();
        }

    }
}