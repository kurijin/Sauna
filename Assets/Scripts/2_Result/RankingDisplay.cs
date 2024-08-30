using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RankingDisplay : MonoBehaviour
{
    public TextMeshProUGUI _rank1Text;
    public TextMeshProUGUI _rank2Text;
    public TextMeshProUGUI _rank3Text;
    public TextMeshProUGUI _rank4Text;
    public TextMeshProUGUI _rank5Text;

    private void Start()
    {
        DisplayRankings();
    }

    private void DisplayRankings()
    {
        // 各順位の表示
        _rank1Text.text = GetRankText(1);
        _rank2Text.text = GetRankText(2);
        _rank3Text.text = GetRankText(3);
        _rank4Text.text = GetRankText(4);
        _rank5Text.text = GetRankText(5);
    }

    private string GetRankText(int rank)
    {
        float time = TimeRanking.Instance.GetTimeAtRank(rank - 1); // リストのインデックスは0から始まる
        if (time >= 0f)
        {
            return rank + ". " + time.ToString("F2") + " seconds";
        }

        return rank + ". ---";
    }
}