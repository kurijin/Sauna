using UnityEngine;

/// <summary>
/// タイトルシーンのボタン管理全部
/// Canvasは合計5つ（タイトル、クレジット、モードセレクト、難易度選択,遊び方)
/// </summary>
public class ButtonSelect : MonoBehaviour
{
    [SerializeField,Header("タイトルのUI")] private GameObject _title;
    [SerializeField,Header("クレジットのUI")] private GameObject _credit;
    [SerializeField,Header("モード画面のUI")] private GameObject _modeSelect;    
    [SerializeField,Header("難易度選択画面のUI")] private GameObject _difficultySelect;
    [SerializeField,Header("遊び方のUI")] private GameObject _howtoPlay;

    /// ボタンの音声
    [SerializeField,Header("サウンドマネージャーのオブジェクト")] private SoundManager _soundManager;
    [SerializeField,Header("ボタンのクリック音")] private AudioClip _buttonSE;
    
    //最初の画面のPlay
    public void OnClickPlayButton()
    {
        _soundManager.PlaySE(_buttonSE);
        _title.SetActive(false);
        _modeSelect.SetActive(true);
    }
    //クレジットボタン
    public void OnClickCreditUI()
    {
        _soundManager.PlaySE(_buttonSE);
        _title.SetActive(false);
        _credit.SetActive(true);
    }
    //遊び方ボタン
    public void OnClickHowtoPlay()
    {
        _soundManager.PlaySE(_buttonSE);
        _title.SetActive(false);
        _howtoPlay.SetActive(true);
    }
    
    //モード選択
    //チャレンジモードボタン
    public void OnClickChallenge()
    {
        _soundManager.PlaySE(_buttonSE);
        _modeSelect.SetActive(false);
        _difficultySelect.SetActive(true);
    }

    //エンドレスボタン
    public void OnClickEndless()
    {
        _soundManager.PlaySE(_buttonSE);
        SceneChanger.Instance.ToMainScene();
    }

    //クレジット、遊び方、モード選択共通のBackボタン
    public void OnClickBacktoTitle()
    {
        _soundManager.PlaySE(_buttonSE);
        _title.SetActive(true);
        _modeSelect.SetActive(false);
        _credit.SetActive(false);
        _howtoPlay.SetActive(false);
    }

    //難易度選択
    //モード選択に戻る
    public void OnClickBacktoMode()
    {
        _soundManager.PlaySE(_buttonSE);
        _modeSelect.SetActive(true);
        _difficultySelect.SetActive(false);
    }

    /// <summary>
    /// 難易度選択後の処理
    /// </summary>
    public void OnClickEasy()
    {
        _soundManager.PlaySE(_buttonSE);
    }

    public void OnClickNormal()
    {
        _soundManager.PlaySE(_buttonSE);
    }

    public void OnClickHard()
    {
        _soundManager.PlaySE(_buttonSE);
    }
}
