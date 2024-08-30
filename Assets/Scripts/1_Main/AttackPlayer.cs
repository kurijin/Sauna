﻿using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField, Header("パワー")] private float _power;
    [SerializeField, Header("時間")] private float _time;
    [SerializeField, Header("HP")] public float _hp = 10;
    [SerializeField, Header("生存判定")] private bool _alive;

    // サウンドマネージャー参照
    protected SoundManager soundManager;

    [SerializeField, Header("出撃音")] private AudioClip _appearSE;
    [SerializeField, Header("死亡音")] protected AudioClip _deathSE;

    private GameObject _supportUI;

    /// 敵が出現してから消えるまでの時間を測る
    private float _elapsedTime;

    protected virtual void Start()
    {
        Transform canvasTransform = gameObject.transform.Find("Canvas");
        _supportUI = canvasTransform.Find("Image")?.gameObject;
        _supportUI.SetActive(false);
        StartCoroutine(Blink());

        GameObject audioManager = GameObject.Find("AudioManager");


        if (audioManager != null)
        {
            soundManager = audioManager.GetComponent<SoundManager>();
        }

        if (soundManager != null && _appearSE != null)
        {
            soundManager.PlaySE(_appearSE);
        }

        _elapsedTime = 0f;
    }

    protected virtual void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1f)
        {
            _supportUI.SetActive(true);
        }

        // 滞在時間を超えたら攻撃
        if (_elapsedTime >= _time)
        {
            Attack();
        }
    }

    // 攻撃処理
    private void Attack()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(_power);

        // aliveがtrueなら消える
        if (_alive)
        {
            Debug.Log("消える");
            Destroy(gameObject);
        }

        // 経過時間リセット
        _elapsedTime = 0f;
    }

    // 敵が死亡する際の処理(派生からしか呼び出せない)
    protected virtual void Die()
    {
        if (soundManager != null && _deathSE != null)
        {
            soundManager.PlaySE(_deathSE);
        }

        // 敵削除
        Destroy(gameObject);
    }

    // 点滅して消える処理
    private IEnumerator Blink()
    {
        while (true)
        {
            _supportUI.GetComponent<CanvasRenderer>().SetAlpha(0f);
            yield return new WaitForSeconds(0.8f);
            _supportUI.GetComponent<CanvasRenderer>().SetAlpha(1f);
            yield return new WaitForSeconds(0.8f);
        }
    }
}