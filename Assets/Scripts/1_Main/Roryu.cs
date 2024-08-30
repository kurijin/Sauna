using UnityEngine;

/// <summary>敵クラス </summary>
public class Roryu : AttackPlayer
{
    // 開始地点と現在位置
    private Vector2 _initialPosition;
    private Vector2 _previousDirection;
    private bool _isUnder;

    private Collider2D _objectCollider2D;

    [SerializeField,Header("鳴らしたいSE")] private AudioClip _hpSE;

     protected override void Start()
    {
        base.Start();
        _objectCollider2D = GetComponent<Collider2D>();
    }

    // 上下にマウススクロールでダメージを受ける処理
    protected override void Update()
    {
        base.Update();
        // コライダー内かどうかで判定する
        if (Input.GetMouseButton(0) && IsMouseInsideCollider())
        {
            // 上下判定で、オブジェクトの中心を上下方向に通り過ぎたらダメージ
            if (_isUnder != Camera.main.WorldToScreenPoint(transform.position).y >= ((Vector2)Input.mousePosition).y)
            {
                // 上下反転
                _isUnder = !_isUnder;

                if (Time.timeScale != 0f)
                {
                    soundManager.PlaySE(_hpSE);
                    _hp--;
                }
                // HPが0になったらキャラクターが死ぬ
                if (_hp <= 0)
                {
                    soundManager.StopSound();
                    Die();
                }
            }
        }
    }

    // コライダーないにマウスがあるかの判定
    private bool IsMouseInsideCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_objectCollider2D != null)
        {
            return _objectCollider2D.OverlapPoint(mousePosition);
        }
        return false;
    }
}
