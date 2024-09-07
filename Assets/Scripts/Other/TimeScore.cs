using UnityEngine;

public class TimeScore : MonoBehaviour
{
    private static TimeScore _TimeScore;

    public static TimeScore Instance => _TimeScore;

    private static float _clearTime;

    private void Awake()
    {
        if (_TimeScore == null)
        {
            _TimeScore = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveTime(float clearTime)
    {
        _clearTime = clearTime;

        Debug.Log($"保存された値： {_clearTime}");
    }

    public float GetTime()
    {
        Debug.Log($"読み込まれた値： {_clearTime}");
        return _clearTime;
    }
}
