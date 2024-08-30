using UnityEngine;
using UnityEngine.UI;

/// <summary>Hp管理</summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField,Header("DamageSE")] private AudioClip _takeDamageSE;
    [SerializeField,Header("死亡時の音")] private AudioClip _deathSE;
    [SerializeField,Header("回復時の音")] private AudioClip _healSE;

    [ReadOnly]
    public int HP;
    public int MaxHP;
    public Slider HpSlider;

    private void Start()
    {
        Initialized();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        _soundManager.PlaySE(_takeDamageSE);
        HP -= (int)damage;
        if (HP < 0)
        {
            HP = 0;
            Dead();
        }
    }

    public void Heal(int amount)
    {
        _soundManager.PlaySE(_healSE);
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
    }

    private void Dead()
    {
        _soundManager.PlaySE(_deathSE);
        InGameFlow.Instance.FinishGame();
    }

    private void Initialized()
    {
        if (HP < MaxHP) HP = MaxHP;
        HpSlider.maxValue = MaxHP;
        HpSlider.value = HP;
    }
    private void UpdateHealthBar()
    {
        HpSlider.value = HP;
    }
}
