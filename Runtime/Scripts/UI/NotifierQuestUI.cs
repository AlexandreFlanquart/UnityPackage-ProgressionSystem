using System.Collections;
using MyUnityPackage.Toolkit;
using TMPro;
using UnityEngine;

namespace MyUnityPackage.ProgressionSystem
{
    public class NotifierQuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;

        public void Setup(Quest quest)
        {
            MUPLogger.Info("Setup NotifierQuestUI - " + " id : " + quest.id + " title : " + quest.title);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            StopAllCoroutines();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            StartCoroutine(HideAfterDelay(3f));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator HideAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Hide();
        }
    }
}