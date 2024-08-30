using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// </<summary>
/// タイトルシーンのボタン管理全部
/// Canvasは合計5つ（タイトル、クレジット、モードセレクト、難易度選択,遊び方)
/// </summary>
/// /// 
public class ButtonSelect : MonoBehaviour
{
    [SerializeField,Header("タイトルのUI")] private GameObject Title;
    [SerializeField,Header("クレジットのUI")] private GameObject credit;
    [SerializeField,Header("モード画面のUI")] private GameObject modeSelect;    
    [SerializeField,Header("難易度選択画面のUI")] private GameObject difficulySelect;
    [SerializeField,Header("遊び方のUI")] private GameObject HowtoPlay;

    /// ボタンの音声
    [SerializeField,Header("サウンドマネージャーのオブジェクト")] private SoundManager _soundManager;
    [SerializeField,Header("ボタンのクリック音")] private AudioClip _buttonSE;


    //最初の画面のPlay
    public void OnClickPlayButton()
    {
        _soundManager.PlaySE(_buttonSE);
        Title.SetActive(false);
        modeSelect.SetActive(true);
    }
    //クレジットボタン
    public void OnClickCreditUI()
    {
        _soundManager.PlaySE(_buttonSE);
        Title.SetActive(false);
        credit.SetActive(true);
    }
    //遊び方ボタン
    public void OnClickHowtoPlay()
    {
        _soundManager.PlaySE(_buttonSE);
        Title.SetActive(false);
        HowtoPlay.SetActive(true);
    }
    

    //モード選択
    //チャレンジモードボタン
    public void OnClickChallenge()
    {
        _soundManager.PlaySE(_buttonSE);
        modeSelect.SetActive(false);
        difficulySelect.SetActive(true);
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
        Title.SetActive(true);
        modeSelect.SetActive(false);
        credit.SetActive(false);
        HowtoPlay.SetActive(false);
    }

    //難易度選択
    //モード選択に戻る
    public void OnClickBacktoMode()
    {
        _soundManager.PlaySE(_buttonSE);
        modeSelect.SetActive(true);
        difficulySelect.SetActive(false);
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
