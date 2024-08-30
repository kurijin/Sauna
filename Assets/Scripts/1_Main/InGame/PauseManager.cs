using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;

    //Pauseメニューの音
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioClip _pauseSE;
    private GameObject _pauseCanvasInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else if (Time.timeScale == 0)
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        _soundManager.PlaySE(_pauseSE);
        Time.timeScale = 0;
        _pauseCanvasInstance = Instantiate(_pauseCanvas);
    }

    private void Resume()
    {
        Time.timeScale = 1;

        if (_pauseCanvasInstance != null)
        {
            Destroy(_pauseCanvasInstance);
        }
    }
}