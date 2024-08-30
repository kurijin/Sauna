using UnityEngine;
using UnityEngine.UI;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField,Header("Startボタン")] private Button _startButton;
    
    private void Start()
    {
        _startButton.onClick.AddListener(SceneChanger.Instance.ToMainScene);
    }
}
