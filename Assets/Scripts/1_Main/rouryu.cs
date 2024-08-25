using UnityEngine;

public class rouryu : AttackPlayer
{
    // �J�n�n�_�ƌ��݈ʒu
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


    // �㉺�Ƀ}�E�X�X�N���[���Ń_���[�W���󂯂鏈��
    protected override void Update()
    {
        base.Update();
        // �R���C�_�[�����ǂ����Ŕ��肷��
        if (Input.GetMouseButton(0) && IsMouseInsideCollider())
        {
            // �㉺����ŁA�I�u�W�F�N�g�̒��S���㉺�����ɒʂ�߂�����_���[�W
            if (isUnder != Camera.main.WorldToScreenPoint(transform.position).y >= ((Vector2)Input.mousePosition).y)
            {
                // �㉺���]
                isUnder = !isUnder;

                if (Time.timeScale != 0f)
                {
                    hp--;
                }
                // HP��0�ɂȂ�����L�����N�^�[������
                if (hp <= 0)
                {
                    Die();
                }
            }
        }
    }

    // �R���C�_�[�Ȃ��Ƀ}�E�X�����邩�̔���
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