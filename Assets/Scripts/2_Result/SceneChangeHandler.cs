using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneChangeHandler : MonoBehaviour
{
    public Button _replayButton;
    public Button _titleButton;

    private void Start()
    {
        _replayButton.onClick.AddListener(Replay);
        _titleButton.onClick.AddListener(Title);
    }

    private static void Replay()
    {
        SceneChanger.Instance.ToMainScene();
    }


    private static void Title()
    {
        SceneChanger.Instance.ToTitleScene();
    }
}