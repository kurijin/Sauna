using UnityEngine;

public class DescriptionClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject _titleUI;
    [SerializeField] private GameObject _descriptionUI;

    //遊び方UIを表示してタイトル画面を非表示にする
    public void OnClickDescriptionUI()
    {
        _titleUI.SetActive(false);
        _descriptionUI.SetActive(true);
    }
    
    //遊び方UIを非表示にしてタイトル画面を表示する
    public void OnClickBackDescriptionUI()
    {
        _titleUI.SetActive(true);
        _descriptionUI.SetActive(false);
    }
}
