using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// バックボタンにタイトルに戻るイベントを追加(遊び方,クレジット共通)バックボタンに直接アタッチ
/// </summary>

public class BackButton : MonoBehaviour
{
    //バックボタンの参照
    private Button _backButton; 
    private ButtonSelect _buttonSelect; 

    private void OnEnable()
    {
        //Pushされるたびにバックボタンにイベント追加
        GameObject buttonManager = GameObject.Find("ButtonManager");
        _buttonSelect = buttonManager.GetComponent<ButtonSelect>();
        _backButton = GetComponent<Button>();
        _backButton.onClick.AddListener(_buttonSelect.OnClickBacktoTitle);
    }
}
