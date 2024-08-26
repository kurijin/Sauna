using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Neppasi : AttackPlayer
{
    private BurnOutEffect _effect;
    private AttackPlayerHealth _health;

    [SerializeField] 
    private AudioClip hpSE;

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
            soundManager.PlaySE(hpSE);
            hp--;
        }

        if (hp <= 0)
        {
            soundManager.StopSound();
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
