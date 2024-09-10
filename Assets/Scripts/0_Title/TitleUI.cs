using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルにボタンイベント追加
/// </summary>

public class TitleUI : MonoBehaviour
{

    [SerializeField,Header("クレジットボタン")] private Button _creditButton;   
    [SerializeField,Header("遊び方ボタン")] private Button _howtoButton;   
    [SerializeField,Header("ゲームスタートボタン")] private Button _playButton; 
    private ButtonSelect _buttonSelect;     

    void Awake()
    {
        GameObject buttonManager = GameObject.Find("ButtonManager");
        _buttonSelect = buttonManager.GetComponent<ButtonSelect>();

        _creditButton.onClick.AddListener(_buttonSelect.OnClickCreditUI);
        _howtoButton.onClick.AddListener(_buttonSelect.OnClickHowtoPlay);
        _playButton.onClick.AddListener(_buttonSelect.OnClickPlayButton);
    }
}
