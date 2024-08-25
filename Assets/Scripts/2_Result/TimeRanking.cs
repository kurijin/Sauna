using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TimeRanking : MonoBehaviour
{
    public static TimeRanking Instance { get; private set; }

    [SerializeField,ReadOnly]
    private List<float> timeScores;

    public bool resetRanking = true;

    private void Awake()
    {
        if (resetRanking) ResetRanking();

        timeScores = new List<float>();
        Instance = this;

        LoadRanking();
        AddTime(TimeScore.Instance.GetTime());
    }

    public void AddTime(float time)
    {
        Debug.Log("タイムの追加");
        timeScores.Add(time);
        timeScores.Sort();
        SaveRanking();
    }

    private void SaveRanking()
    {
        for (int i = 0; i < timeScores.Count; i++)
        {
            PlayerPrefs.SetFloat("TimeScore" + i, timeScores[i]);
        }
        PlayerPrefs.SetInt("RankingCount", timeScores.Count);
        PlayerPrefs.Save();
    }

    private void LoadRanking()
    {
        int count = PlayerPrefs.GetInt("RankingCount", 0);
        for (int i = 0; i < count; i++)
        {
            timeScores.Add(PlayerPrefs.GetFloat("TimeScore" + i, 0f));
        }
        timeScores.Sort();
    }

    public string GetTop5Rankings()
    {
        string rankingText = "Top 5 Rankings:\n";
        for (int i = timeScores.Count; i < Mathf.Min(5, timeScores.Count); i++)
        {
            rankingText += (i + 1) + ". " + timeScores[i].ToString("F2") + " seconds\n";
        }
        return rankingText;
    }

    public float GetTimeAtRank(int rank)
    {
        if (timeScores.Count - rank < 0 || rank >= timeScores.Count)
        {
            return -1f;
        }

        return timeScores[timeScores.Count - rank - 1];
    }

    public List<float> GetAllRankings()
    {
        return new List<float>(timeScores);
    }

    public void ResetRanking()
    {
        int count = PlayerPrefs.GetInt("RankingCount", 0);

        for (int i = 0; i < count; i++)
        {
            PlayerPrefs.DeleteKey("TimeScore" + i);
        }

        PlayerPrefs.DeleteKey("RankingCount");

        PlayerPrefs.Save();

        timeScores.Clear();
    }

}
