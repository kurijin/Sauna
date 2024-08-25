using UnityEngine;

/// <summary>音を鳴らす処理をまとめたクラス</summary>
public class SoundManager : MonoBehaviour
{
   private AudioSource _audioSource;

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   /// <summary>SEを1回だけ鳴らす</summary>
   /// /// <param name="clipName">再生するAudioClipの名前</param>
   public void PlaySE(AudioClip clipName)
   {
      _audioSource.PlayOneShot(clipName);
   }

   /// <summary>音を止める</summary>
   public void StopSound()
   {
      _audioSource.Stop();
   }
}
