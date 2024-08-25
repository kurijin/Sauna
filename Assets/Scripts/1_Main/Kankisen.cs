using UnityEngine;

public class Kankisen : AttackPlayer
{
    //始点と現在位置の変数
    private Vector2 initialPosition;  
    private Vector2 previousDirection;
    private float angleSum = 0f;  
    private Collider2D objectCollider2D;

    protected override void Start()
    {
        base.Start();
        // オブジェクトに付いているコライダーを取得
        objectCollider2D = GetComponent<Collider2D>();
    }

    protected override void Update()
    {
        base.Update();
        //コライダー内かどうかで判定する
        if (Input.GetMouseButtonDown(0) && IsMouseInsideCollider())
        {
            // ぐるぐるをし始める場所の記録、オブジェクト中心にぐるぐるが検出される
            initialPosition = Camera.main.WorldToScreenPoint(transform.position);
            previousDirection = (Vector2)Input.mousePosition - initialPosition;
            angleSum = 0f;
        }

        if (Input.GetMouseButton(0) && IsMouseInsideCollider())
        {
            Vector2 currentDirection = (Vector2)Input.mousePosition - initialPosition;

            // 角度差を計算
            float angle = Vector2.SignedAngle(previousDirection, currentDirection);
            angleSum += angle;

            // 360度を超えるとhp減らす
            if (Mathf.Abs(angleSum) >= 360f)
            {
                if (Time.timeScale != 0f)
                {
                    hp--;
                }
                angleSum = 0f;  
            }

            // HPが0になったらキャラクターが死ぬ
            if (hp <= 0)
            {
                Die();
            }

            // 現在の方向を記録
            previousDirection = currentDirection;
        }
    }

    //コライダーないにあるかの判定
    private bool IsMouseInsideCollider()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (objectCollider2D != null)
        {
            return objectCollider2D.OverlapPoint(mousePosition);
        }

        return false;
    }
}
