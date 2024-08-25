using TMPro;
using UnityEngine;

public class RankingDisplay : MonoBehaviour
{
    public TextMeshProUGUI rank1Text;
    public TextMeshProUGUI rank2Text;
    public TextMeshProUGUI rank3Text;
    public TextMeshProUGUI rank4Text;
    public TextMeshProUGUI rank5Text;
    private void Start()
    {
        DisplayRankings();
    }

    public void DisplayRankings()
    {

        // 各順位の表示
        rank1Text.text = GetRankText(1);
        rank2Text.text = GetRankText(2);
        rank3Text.text = GetRankText(3);
        rank4Text.text = GetRankText(4);
        rank5Text.text = GetRankText(5);
    }

    private string GetRankText(int rank)
    {
        float time = TimeRanking.Instance.GetTimeAtRank(rank - 1); // リストのインデックスは0から始まる
        if (time >= 0f)
        {
            return rank + ". " + time.ToString("F2") + " seconds";
        }
        else
        {
            return rank + ". ---";
        }
    }
}
