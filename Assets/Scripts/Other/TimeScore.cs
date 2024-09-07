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

        Debug.Log($"�ۑ����ꂽ�l�F {_clearTime}");
    }

    public float GetTime()
    {
        Debug.Log($"�ǂݍ��܂ꂽ�l�F {_clearTime}");
        return _clearTime;
    }
}
