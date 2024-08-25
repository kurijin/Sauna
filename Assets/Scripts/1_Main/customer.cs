using UnityEngine;

public class customer : AttackPlayer
{
    private float timeSinceLastDamage;
    public float damageInterval = 1f;  // ダメージを受ける間隔（秒）
    private Collider2D objectCollider2D;

    [SerializeField]
    private ParticleSystem _particle;

    private BurnOutEffect _effect;
    
    private AttackPlayerHealth _health;

    protected override void Start()
    {
        base.Start();
        _health = this.GetComponent<AttackPlayerHealth>();
        objectCollider2D = GetComponent<Collider2D>();
        _effect = GetComponent<BurnOutEffect>();
        timeSinceLastDamage = 0f;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButton(0) && IsMouseInsideCollider())  
        {
            timeSinceLastDamage += Time.deltaTime;

            if (timeSinceLastDamage >= damageInterval)
            {
                if (Time.timeScale != 0f)
                {
                    hp--;
                    //1秒ごとに押している時間リセット
                    timeSinceLastDamage = 0f;  
                }

                if (hp <= 0)
                {
                    Die();
                }
            }
        }
    }

    // コライダーないにマウスがあるかの判定
    private bool IsMouseInsideCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (objectCollider2D != null)
        {
            return objectCollider2D.OverlapPoint(mousePosition);
        }
        return false;
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
