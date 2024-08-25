using UnityEngine;

public class CreditButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject _titleUI;
    [SerializeField] private GameObject _creditUI;

    //クレジットUIを表示してタイトル画面を非表示にする
    public void OnClickCreditUI()
    {
        _titleUI.SetActive(false);
        _creditUI.SetActive(true);
    }
    
    //クレジットUIを非表示にしてタイトル画面を表示する
    public void OnClickBackCreditUI()
    {
        _titleUI.SetActive(true);
        _creditUI.SetActive(false);
    }
}
