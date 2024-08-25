using UnityEngine;

public class FinishCanvas : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneChanger.Instance.ToResultScene();
            Time.timeScale = 1;
        }
    }
}
