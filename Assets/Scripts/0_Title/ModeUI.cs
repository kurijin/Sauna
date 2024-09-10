using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モード選択ボタンにイベントを追加する
/// </summary>

public class ModeUI : MonoBehaviour
{

    [SerializeField,Header("チャレンジモードボタン")] private Button _challangeButton;   
    [SerializeField,Header("エンドレスモードボタン")] private Button _endlessButton;   
    [SerializeField,Header("backボタン")] private Button _backButton; 
    
    private ButtonSelect _buttonSelect;     

    private void OnEnable()
    {
        GameObject buttonManager = GameObject.Find("ButtonManager");
        _buttonSelect = buttonManager.GetComponent<ButtonSelect>();

        _challangeButton.onClick.AddListener(_buttonSelect.OnClickChallenge);
        _endlessButton.onClick.AddListener(_buttonSelect.OnClickEndless);
        _backButton.onClick.AddListener(_buttonSelect.OnClickCloseModal);
    }
}
