using UnityEngine;

public class VentilationFan : AttackPlayer
{
    //始点と現在位置の変数
    private Vector2 _initialPosition;  
    private Vector2 _previousDirection;
    private float _angleSum;  
    private Collider2D _col;

    [SerializeField,Header("鳴らしたいSE")] private AudioClip _hpSE;

    protected override void Start()
    {
        base.Start();
        // オブジェクトに付いているコライダーを取得
        _col = GetComponent<BoxCollider2D>();
    }

    protected override void Update()
    {
        base.Update();
        //コライダー内かどうかで判定する
        if (Input.GetMouseButtonDown(0) && IsMouseInsideCollider() && CanBeAttacked())
        {
            // ぐるぐるをし始める場所の記録、オブジェクト中心にぐるぐるが検出される
            _initialPosition = Camera.main.WorldToScreenPoint(transform.position);
            _previousDirection = (Vector2)Input.mousePosition - _initialPosition;
            _angleSum = 0f;
        }

        if (Input.GetMouseButton(0) && IsMouseInsideCollider() && CanBeAttacked())
        {
            Vector2 currentDirection = (Vector2)Input.mousePosition - _initialPosition;

            // 角度差を計算
            float angle = Vector2.SignedAngle(_previousDirection, currentDirection);
            _angleSum += angle;

            // 360度を超えるとhp減らす
            if (Mathf.Abs(_angleSum) >= 360f)
            {
                if (Time.timeScale != 0f)
                {
                    soundManager.PlaySE(_hpSE);
                    _hp--;
                }
                _angleSum = 0f;  
            }

            // HPが0になったらキャラクターが死ぬ
            if (_hp <= 0)
            {
                soundManager.StopSound();
                Die();
            }

            // 現在の方向を記録
            _previousDirection = currentDirection;
        }
    }

    //コライダー内にあるかの判定
    private bool IsMouseInsideCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_col != null)
        {
            return _col.OverlapPoint(mousePosition);
        }

        return false;
    }
}
