using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI countText;

    public void Setup(string _title, string _description, int _count)
    {
        titleText.text = _title;
        descriptionText.text = _description;
        countText.text = "0 / " + _count;
    }

    public void SetCount(int count, int max)
    {
         countText.text = count + " / " + max;
    }
}
