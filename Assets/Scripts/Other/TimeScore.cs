using UnityEngine;

public class TimeScore : MonoBehaviour
{
    private static TimeScore _TimeScore;

    public static TimeScore Instance => _TimeScore;

    private static float _clearTime = 0;

    private void Awake()
    {
        if (_TimeScore == null)
        {
            _TimeScore = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
