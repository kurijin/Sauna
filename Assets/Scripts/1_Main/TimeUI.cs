using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = TimeManager.Instance?.GetTime().ToString("F2");
    }
}
