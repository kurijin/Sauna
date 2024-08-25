using UnityEngine;

public class TimeScoreManager : MonoBehaviour
{
    public static TimeScoreManager Instance { get; private set; }

    private float _time = 0;

    public float GetTime() => _time;

    private void Awake()
    {
        _time = 0;

        Instance = this;
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    /*
    private float startTime;
    private bool isTiming;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public float GetElapsedTime()
    {
        if (isTiming)
        {
            return Time.time - startTime;
        }
        else
        {
            return 0f;
        }
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }
    */
}
