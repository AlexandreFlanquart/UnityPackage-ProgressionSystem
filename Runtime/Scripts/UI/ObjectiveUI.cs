using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI countText;

    public void Setup(string _title, string _description, string _count)
    {
        titleText.text = _title;
        descriptionText.text = _description;
        countText.text = _count;
    }

    public void SetCount(int count, int max)
    {
        string.Format(countText.text, count, max);
    }
}
