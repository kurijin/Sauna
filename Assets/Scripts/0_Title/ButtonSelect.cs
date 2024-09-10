using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityEngine.UI;
using System.Collections; 

/// <summary>
/// タイトルシーン遷移管理
/// Canvasは合計5つ（タイトル、クレジット、モードセレクト、難易度選択,遊び方)
/// </summary>

public class ButtonSelect : MonoBehaviour
{
    [SerializeField, Header("サウンドマネージャーのオブジェクト")] private SoundManager _soundManager;
    [SerializeField, Header("ボタンのクリック音")] private AudioClip _buttonSE;
    [SerializeField,Header("シーン管理のCanvasを参照(page)")] private PageContainer _pageContainer;
    [SerializeField,Header("シーン管理のCanvasを参照(modal)")] private ModalContainer _modalContainer;

    // 最初の画面のPlay
    public void OnClickPlayButton()
    {
        StartCoroutine(PlaySoundAndPushModal("ModeModal"));
    }

    // クレジットボタン
    public void OnClickCreditUI()
    {
        StartCoroutine(PlaySoundAndPushPage("CreditPage"));
    }

    // 遊び方ボタン
    public void OnClickHowtoPlay()
    {
        StartCoroutine(PlaySoundAndPushPage("HowtoPage"));
    }

    // モード選択

    // チャレンジモードボタン
    public void OnClickChallenge()
    {
        StartCoroutine(PlaySoundAndPushModal("DifficultyModal"));
    }

    // エンドレスボタン
    public void OnClickEndless()
    {
        _soundManager.PlaySE(_buttonSE);
        SceneChanger.Instance.ToMainScene();
    }


    // 共通のコルーチンメソッド(ページ)
    private IEnumerator PlaySoundAndPushPage(string pageName)
    {
        _soundManager.PlaySE(_buttonSE);
        yield return _pageContainer.Push(pageName, true);
    }

    // 共通のコルーチンメソッド(モーダル)
    private IEnumerator PlaySoundAndPushModal(string pageName)
    {
        _soundManager.PlaySE(_buttonSE);
        yield return _modalContainer.Push(pageName, true);
    }

    // クレジット、遊び方共通のBackボタン
    public void OnClickBacktoTitle()
    {
        StartCoroutine(BackToTitleCoroutine());
    }

    private IEnumerator BackToTitleCoroutine()
    {
        _soundManager.PlaySE(_buttonSE);
        yield return _pageContainer.Pop(true);
    }

    // モード選択、難易度選択共通のbackボタン
    public void OnClickCloseModal()
    {
        StartCoroutine(CloseModalCoroutine());
    }

    private IEnumerator CloseModalCoroutine()
    {
        _soundManager.PlaySE(_buttonSE);
        yield return _modalContainer.Pop(true);
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
