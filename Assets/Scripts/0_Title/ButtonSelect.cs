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
    [SerializeField] private GameObject Title;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject modeSelect;    
    [SerializeField] private GameObject difficulySelect;
    [SerializeField] private GameObject HowtoPlay;

    /// ボタンの音声
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip buttonSE;


    //最初の画面のPlay
    public void OnClickPlayButton()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(false);
        modeSelect.SetActive(true);
    }
    //クレジットボタン
    public void OnClickCreditUI()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(false);
        credit.SetActive(true);
    }
    //遊び方ボタン
    public void OnClickHowtoPlay()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(false);
        HowtoPlay.SetActive(true);
    }
    

    //モード選択
    //チャレンジモードボタン
    public void OnClickChallenge()
    {
        soundManager.PlaySE(buttonSE);
        modeSelect.SetActive(false);
        difficulySelect.SetActive(true);
    }

    //エンドレスボタン
    public void OnClickEndless()
    {
        soundManager.PlaySE(buttonSE);
        SceneChanger.Instance.ToMainScene();
    }

    //クレジット、遊び方、モード選択共通のBackボタン
    public void OnClickBacktoTitle()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(true);
        modeSelect.SetActive(false);
        credit.SetActive(false);
        HowtoPlay.SetActive(false);
    }

    //難易度選択
    //モード選択に戻る
    public void OnClickBacktoMode()
    {
        soundManager.PlaySE(buttonSE);
        modeSelect.SetActive(true);
        difficulySelect.SetActive(false);
    }

    /// <summary>
    /// 難易度選択後の処理
    /// </summary>
    public void OnClickEasy()
    {
        soundManager.PlaySE(buttonSE);
    }

    public void OnClickNormal()
    {
        soundManager.PlaySE(buttonSE);
    }

    public void OnClickHard()
    {
        soundManager.PlaySE(buttonSE);
    }
}
