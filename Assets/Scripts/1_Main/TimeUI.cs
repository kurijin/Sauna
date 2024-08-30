using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _text;

    void Update()
    {
        _text.text = TimeManager.Instance?.GetTime().ToString("F2");
    }
}
