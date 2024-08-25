using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger _SceneChanger;

    public static SceneChanger Instance => _SceneChanger;

    private GameObject _sceneChanger;

    private void Awake()
    {
        if(Instance == null)
        {
            _SceneChanger = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("0_TitleScene");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("1_MainScene");
    }

    public void ToResultScene()
    {
        SceneManager.LoadScene("2_ResultScene");
    }
}
