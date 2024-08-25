using UnityEngine;

public class InGameFlow : MonoBehaviour
{
    private static InGameFlow _InGameFlow;

    public static InGameFlow Instance => _InGameFlow;

    [SerializeField]
    private Transform _player;

    [SerializeField,ReadOnly]
    private Difficulty[] _difficulty;

    [SerializeField]
    private float[] _difficultyTime;

    private int _difficultyID = 0;

    private float _aliveTime = 0;

    [SerializeField]
    private GameObject _startTimer;

    [SerializeField]
    private GameObject _timeManager;

    private GameObject _timeManagerInstance;

[SerializeField]
    private GameObject _finishCanvas;

    private GameObject _finishCanvasInstance;



    private bool _isStart = false;

    public void StartGame()
    {
        _isStart = true;
    }

    private bool _isFinish = false;

    public void FinishGame()
    {
        _isFinish = true;
    }

    private void Awake()
    {
        _InGameFlow = this;
        _difficulty = this.GetComponentsInChildren<Difficulty>();
        SetDifficulty(-1);
    }

    private void Start()
    {
        _isStart = false;
        _difficultyID = 0;
        _aliveTime = 0;
        

        if (_difficulty.Length != _difficultyTime.Length)
        {
            Debug.LogError("個数がマッチしていません");
        }

        //クリックでスタートのカウントダウン
        StartTimer();
    }

    /// <summary>
    /// スタートまでのカウント
    /// </summary>
    private void StartTimer()
    {
        Instantiate(_startTimer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            FinishGame();
        }

        if (_isStart == true && _isFinish == false)
        {
            Debug.Log("スタート");

            if(_timeManagerInstance == null)
            {
                _timeManagerInstance = Instantiate(_timeManager);
            }
            

            DifficultyManage();
        }

        if (_isFinish == true)
        {
            Debug.Log("終了");
            SetDifficulty(-1);
            //終了時にクリックでリザルト画面
            if (_finishCanvasInstance == null)
            {
                _finishCanvasInstance = Instantiate(_finishCanvas);
                TimeScore.Instance.SaveTime(TimeManager.Instance.GetTime());
            }
            
        }
    }

    private void DifficultyManage()
    {
        _aliveTime += Time.deltaTime;

        if (_aliveTime > _difficultyTime[_difficultyID])
        {
            SetDifficulty(_difficultyID);
            if (_difficultyTime.Length - 1 > _difficultyID)
            {
                _difficultyID++;
            }
        }
    }

    private void SetDifficulty(int difficultyID)
    {
        for (int i = 0; i < _difficulty.Length; i++)
        {
            if (i == difficultyID)
            {
                _difficulty[i].gameObject.SetActive(true);
            }
            else
            {
                _difficulty[i].gameObject.SetActive(false);
            }
        }
    }
}
