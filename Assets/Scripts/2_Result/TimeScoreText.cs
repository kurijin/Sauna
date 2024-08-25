using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScoreText : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"記録： {TimeScore.Instance.GetTime().ToString("F2")} !!";
    }

}
