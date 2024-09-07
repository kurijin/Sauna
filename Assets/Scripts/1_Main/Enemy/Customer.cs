using UnityEngine;
using UnityEngine.UI;

public class Customer : AttackPlayer
{
    private float _timeSinceLastDamage;
    public float _damageInterval = 1f;  // ダメージを受ける間隔（秒）
    private Collider2D _objectCollider2D;

    [SerializeField] private ParticleSystem _particle;

    private BurnOutEffect _effect;
    private AttackPlayerHealth _health;

    [SerializeField] private Slider _hpSlider;
    [SerializeField] private AudioClip _hpSE;

    protected override void Start()
    {
        base.Start();
        _health = GetComponent<AttackPlayerHealth>();
        _objectCollider2D = GetComponent<Collider2D>();
        _effect = GetComponent<BurnOutEffect>();
        _timeSinceLastDamage = 0f;

        _hpSlider.maxValue = _damageInterval;
        _hpSlider.value = _damageInterval;
        _hpSlider.gameObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0) && IsMouseInsideCollider() && CanBeAttacked())  
        {
            if (Time.timeScale != 0f)
            {
                _timeSinceLastDamage += Time.deltaTime;
                _hpSlider.gameObject.SetActive(true);
                _hpSlider.value = Mathf.Clamp(_damageInterval - _timeSinceLastDamage, 0, _damageInterval);

                // 一定時間経過後にHPを減らし、スライダーをリセット
                if (_timeSinceLastDamage >= _damageInterval)
                {
                    soundManager.PlaySE(_hpSE);
                    _hp--;
                    _timeSinceLastDamage = 0f;  

                    if (_hp <= 0)
                    {
                        soundManager.StopSound();
                        Die();
                    }
                }
            }
        }
        else
        {
            _hpSlider.gameObject.SetActive(false);
            _hpSlider.value = Mathf.Lerp(_hpSlider.value, _damageInterval, Time.deltaTime * 5f);
            _timeSinceLastDamage = 0f;
        }
    }

    // コライダー内にマウスがあるかの判定
    private bool IsMouseInsideCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_objectCollider2D != null)
        {
            return _objectCollider2D.OverlapPoint(mousePosition);
        }
        return false;
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
