using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Neppasi : AttackPlayer
{
    private BurnOutEffect _effect;
    private AttackPlayerHealth _health;

    protected override void Start()
    {
        base.Start();
        _health = this.GetComponent<AttackPlayerHealth>();
        _effect = this.GetComponent<BurnOutEffect>();
    }

    // オブジェクトがクリックされたらhpが減る、hp0でEnemyのDie()を呼ぶ。
    void OnMouseDown()
    {
        if (Time.timeScale != 0f)
        {
            hp--;
        }

        if (hp <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        _effect.StartBurning();

        if (soundManager != null && deathSE != null)
        {
            soundManager.PlaySE(deathSE);
        }

        _health.SetText("");
        Destroy(_health);

        Destroy(this);
        
        //base.Die();
    }
}
