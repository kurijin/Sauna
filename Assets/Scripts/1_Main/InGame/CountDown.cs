using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private float _countDownTime;

    [ReadOnly]
    private float _currentTime;

    private TextMeshProUGUI _countDownText;
    
    private SoundManager _soundManager;
    
    [SerializeField,Header("スタート音")] private AudioClip _startSE;

    private void Awake()
    {
        _countDownText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        var diff = _countDownTime - _currentTime;

        _countDownText.text = diff.ToString("0");

        if (diff < 1)
        {
            _countDownText.text = "スタート";
        }

        if (diff < 0)
        {
            GameObject audioManager = GameObject.Find("AudioManager");
            if (audioManager != null)
            {
                _soundManager = audioManager.GetComponent<SoundManager>();
            }

            if (_soundManager != null && _startSE != null)
            {
                _soundManager.PlaySE(_startSE);
            }

            Debug.Log("カウントダウン終了");
            InGameFlow.Instance.StartGame();
            Destroy(this.transform.root.gameObject);
        }
    }
}
