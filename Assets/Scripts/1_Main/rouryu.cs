using UnityEngine;

public class rouryu : AttackPlayer
{
    // 開始地点と現在位置
    private Vector2 initialPosition;
    private Vector2 previousDirection;
    private bool isUnder = false;

    private Collider2D objectCollider2D;

     protected override void Start()
    {
        base.Start();
        objectCollider2D = GetComponent<Collider2D>();
    }

    // protected override void Start()
    // {
    //     base.Start();
    //     objectCollider2D = GetComponent<Collider2D>();
    // }


    // 上下にマウススクロールでダメージを受ける処理
    protected override void Update()
    {
        base.Update();
        // コライダー内かどうかで判定する
        if (Input.GetMouseButton(0) && IsMouseInsideCollider())
        {
            // 上下判定で、オブジェクトの中心を上下方向に通り過ぎたらダメージ
            if (isUnder != Camera.main.WorldToScreenPoint(transform.position).y >= ((Vector2)Input.mousePosition).y)
            {
                // 上下反転
                isUnder = !isUnder;

                if (Time.timeScale != 0f)
                {
                    hp--;
                }
                // HPが0になったらキャラクターが死ぬ
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
}