using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// </<summary>
/// タイトルシーンのボタン管理全部
/// Canvasは合計4つ（タイトル、クレジット、モードセレクト、難易度選択)
/// </summary>
public class ButtonSelect : MonoBehaviour
{
    [SerializeField] private GameObject Title;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject modeSelect;    
    [SerializeField] private GameObject difficulySelect;

    /// ボタンの音声
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip buttonSE;

    public void OnClickStart()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(false);
        modeSelect.SetActive(true);
    }
    public void OnClickChallenge()
    {
        soundManager.PlaySE(buttonSE);
        modeSelect.SetActive(false);
        difficulySelect.SetActive(true);
    }

    public void OnClickEndless()
    {
        soundManager.PlaySE(buttonSE);
        SceneChanger.Instance.ToMainScene();
    }

    public void OnClickBacktoTitle()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(true);
        modeSelect.SetActive(false);
    }

    public void OnClickBacktoMode()
    {
        soundManager.PlaySE(buttonSE);
        modeSelect.SetActive(true);
        difficulySelect.SetActive(false);
    }

    public void OnClickCreditUI()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(false);
        credit.SetActive(true);
    }

    public void OnClickBackCreditUI()
    {
        soundManager.PlaySE(buttonSE);
        Title.SetActive(true);
        credit.SetActive(false);
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

    public void OnClickDifficult()
    {
        soundManager.PlaySE(buttonSE);
    }
}
