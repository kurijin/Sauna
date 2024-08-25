using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseCanvas;
    //Pauseメニューの音
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip pauseSE;
    private GameObject _pauseCanvasInstance;

    // Update is called once per frame
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
        soundManager.PlaySE(pauseSE);
        Time.timeScale = 0;
        _pauseCanvasInstance = Instantiate(_pauseCanvas);

    }

    private void Resume()
    {
        Time.timeScale = 1;

        if( _pauseCanvasInstance != null)
        {
            Destroy(_pauseCanvasInstance);
        }
        
    }
}
