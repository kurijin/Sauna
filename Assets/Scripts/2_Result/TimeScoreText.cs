using TMPro;
using UnityEngine;

public class TimeScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = $"記録： {TimeScore.Instance.GetTime().ToString("F2")} !!";
    }

}
