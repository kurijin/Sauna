using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour
{
    /// 攻撃力と攻撃するまで滞在する時間 
    [SerializeField] private float power;
    [SerializeField] private float time;
    [SerializeField] public float hp = 10;
    //生きてるかどうかチェック
    [SerializeField] private bool alive = false;

    // サウンドマネージャー参照
    protected SoundManager soundManager;

    // 出撃音と死亡音とプレイヤーのダメージのAudioClip
    [SerializeField] private AudioClip appearSE;
    [SerializeField] protected AudioClip deathSE;

    private GameObject supportUI;

    /// 敵が出現してから消えるまでの時間を測る
    private float elapsedTime;

    protected virtual void Start()
    {
        Transform canvasTransform = gameObject.transform.Find("Canvas");
        supportUI = canvasTransform.Find("Image")?.gameObject;
        supportUI.SetActive(false);
        StartCoroutine(Blink());

        GameObject audioManager = GameObject.Find("AudioManager");


        if (audioManager != null)
        {
            soundManager = audioManager.GetComponent<SoundManager>();
        }

        if (soundManager != null && appearSE != null)
        {
            soundManager.PlaySE(appearSE);
        }

        elapsedTime = 0f;
    }

    protected virtual void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= 1f)
        {
            supportUI.SetActive(true);
        }
    
        // 滞在時間を超えたら攻撃
        if (elapsedTime >= time)
        {
            Attack();
        }
    }

    // 攻撃処理
    private void Attack()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(power);

        // aliveがtrueなら消える
        if (alive)
        {
            Debug.Log("消える");
            Destroy(gameObject);
        }

        // 経過時間リセット
        elapsedTime = 0f;
    }

    // 敵が死亡する際の処理(派生からしか呼び出せない)
    protected virtual void Die()
    {
        if (soundManager != null && deathSE != null)
        {
            soundManager.PlaySE(deathSE);
        }

        // 敵削除
        Destroy(gameObject);
    }

    // 点滅して消える処理
    private IEnumerator Blink()
    {
        while (true) 
        {
            supportUI.GetComponent<CanvasRenderer>().SetAlpha(0f); 
            yield return new WaitForSeconds(0.8f); 
            supportUI.GetComponent<CanvasRenderer>().SetAlpha(1f); 
            yield return new WaitForSeconds(0.8f); 
        }
    }
}
