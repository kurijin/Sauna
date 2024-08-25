using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    // プレイヤーのダメージと回復音と死亡音のAudioClip
    [SerializeField] private AudioClip takeDamegeSE;
    [SerializeField] private AudioClip DeathSE;
    [SerializeField] private AudioClip HealSE;

    [ReadOnly]
    public int HP;
    public int maxHP;
    public Slider HpSlider;

    void Start()
    {
        _Initialized();
    }

    private void Update()
    {
        _UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        soundManager.PlaySE(takeDamegeSE);
        HP -= (int)damage;
        if (HP < 0)
        {
            HP = 0;
            Dead();
        }
    }

    public void Heal(int amount)
    {
        soundManager.PlaySE(HealSE);
        HP += amount;
        if (HP > maxHP) HP = maxHP;
    }

    private void Dead()
    {
        soundManager.PlaySE(DeathSE);
        InGameFlow.Instance.FinishGame();
    }

    private void _Initialized()
    {
        if (HP < maxHP) HP = maxHP;
        HpSlider.maxValue = maxHP;
        HpSlider.value = HP;
    }
    private void _UpdateHealthBar()
    {
        HpSlider.value = HP;
    }
}
