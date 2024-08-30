using UnityEngine;

public class HeatWaveTherapist : AttackPlayer
{
    private BurnOutEffect _effect;
    private AttackPlayerHealth _health;

    [SerializeField] private AudioClip _hpSE;

    protected override void Start()
    {
        base.Start();
        _health = GetComponent<AttackPlayerHealth>();
        _effect = GetComponent<BurnOutEffect>();
    }

    // オブジェクトがクリックされたらhpが減る、hp0でEnemyのDie()を呼ぶ。
    private void OnMouseDown()
    {
        if (Time.timeScale != 0f)
        {
            soundManager.PlaySE(_hpSE);
            _hp--;
        }

        if (_hp <= 0)
        {
            soundManager.StopSound();
            Die();
        }
    }

    protected override void Die()
    {
        _effect.StartBurning();

        if (soundManager != null && _deathSE != null)
        {
            soundManager.PlaySE(_deathSE);
        }

        _health.SetText("");
        Destroy(_health);
        Destroy(this);
    }
}