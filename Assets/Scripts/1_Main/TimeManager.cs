using UnityEngine;

/// <summary>シングルトンクラス</summary>
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private float _time;

    public float GetTime() => _time;

    private void Awake()
    {
        Instance = this;
        _time = 0;
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void OnDisable()
    {
        _time = 0;
    }
}
