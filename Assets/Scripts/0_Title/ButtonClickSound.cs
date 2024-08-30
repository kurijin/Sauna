using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField,Header("サウンドを管理するオブジェクト")] private SoundManager _soundManager;
    [SerializeField,Header("鳴らしたいSE音")] private AudioClip _buttonSE;

    //Buttonのクリックイベントで呼ぶクラス
    public void PlayButtonSound()
    {
        if (_soundManager != null && _buttonSE != null)
        {
            _soundManager.PlaySE(_buttonSE);
        }
    }
}
