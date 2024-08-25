using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    public Button replayButton;  
    public Button titleButton;   

    void Start()
    {
        replayButton.onClick.AddListener(() => Replay());
        titleButton.onClick.AddListener(() => Title());
    }

    void Replay()
    {
        SceneChanger.Instance.ToMainScene();
    }  
  
    
    void Title()
    {
        SceneChanger.Instance.ToTitleScene();
    }
}
