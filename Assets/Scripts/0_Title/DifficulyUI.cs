using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 難易度選択のボタンにイベントを追加する
/// </summary>

public class DifficulyUI : MonoBehaviour
{
    [SerializeField,Header("easyステージへのボタン")] private Button _easyButton;   
    [SerializeField,Header("normalステージへのボタン")] private Button _normalButton;   
    [SerializeField,Header("hardステージへのボタン")] private Button _hardButton; 
    [SerializeField,Header("backボタン")] private Button _backButton; 
    
    private ButtonSelect _buttonSelect;     

    private void OnEnable()
    {
        GameObject buttonManager = GameObject.Find("ButtonManager");
        _buttonSelect = buttonManager.GetComponent<ButtonSelect>();

        _easyButton.onClick.AddListener(_buttonSelect.OnClickEasy);
        _normalButton.onClick.AddListener(_buttonSelect.OnClickNormal);
        _hardButton.onClick.AddListener(_buttonSelect.OnClickHard);
        _backButton.onClick.AddListener(_buttonSelect.OnClickCloseModal);
    }
}
