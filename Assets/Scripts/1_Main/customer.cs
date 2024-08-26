using UnityEngine;
using UnityEngine.UI;

public class Customer : AttackPlayer
{
    private float timeSinceLastDamage;
    public float damageInterval = 1f;  // ダメージを受ける間隔（秒）
    private Collider2D objectCollider2D;

    [SerializeField]
    private ParticleSystem _particle;

    private BurnOutEffect _effect;
    private AttackPlayerHealth _health;

    [SerializeField]
    private Slider hpSlider;  

    [SerializeField] 
    private AudioClip hpSE;

    protected override void Start()
    {
        base.Start();
        _health = GetComponent<AttackPlayerHealth>();
        objectCollider2D = GetComponent<Collider2D>();
        _effect = GetComponent<BurnOutEffect>();
        timeSinceLastDamage = 0f;

        hpSlider.maxValue = damageInterval;
        hpSlider.value = damageInterval;
        hpSlider.gameObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0) && IsMouseInsideCollider())  
        {
            if (Time.timeScale != 0f)
            {
                timeSinceLastDamage += Time.deltaTime;
                hpSlider.gameObject.SetActive(true);
                hpSlider.value = Mathf.Clamp(damageInterval - timeSinceLastDamage, 0, damageInterval);

                // 一定時間経過後にHPを減らし、スライダーをリセット
                if (timeSinceLastDamage >= damageInterval)
                {
                    soundManager.PlaySE(hpSE);
                    hp--;
                    timeSinceLastDamage = 0f;  

                    if (hp <= 0)
                    {
                        soundManager.StopSound();
                        Die();
                    }
                }
            }
        }
        else
        {
            hpSlider.gameObject.SetActive(false);
            hpSlider.value = Mathf.Lerp(hpSlider.value, damageInterval, Time.deltaTime * 5f);
            timeSinceLastDamage = 0f;
        }
    }

    // コライダー内にマウスがあるかの判定
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
        // base.Die();
    }
}
