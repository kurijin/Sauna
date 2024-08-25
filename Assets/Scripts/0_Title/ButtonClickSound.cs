using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip buttonSE;

    public void PlayButtonSound()
    {
        if (soundManager != null && buttonSE != null)
        {
            soundManager.PlaySE(buttonSE);
        }
    }
}
