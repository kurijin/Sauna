using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(SceneChanger.Instance.ToMainScene);
    }
}
