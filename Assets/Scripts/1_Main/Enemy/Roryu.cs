using UnityEngine;

/// <summary>�G�N���X </summary>
public class Roryu : AttackPlayer
{
    // �J�n�n�_�ƌ��݈ʒu
    private Vector2 _initialPosition;
    private Vector2 _previousDirection;
    private bool _isUnder;

    private Collider2D _objectCollider2D;

    [SerializeField,Header("�炵����SE")] private AudioClip _hpSE;

     protected override void Start()
    {
        base.Start();
        _objectCollider2D = GetComponent<Collider2D>();
    }

    // �㉺�Ƀ}�E�X�X�N���[���Ń_���[�W���󂯂鏈��
    protected override void Update()
    {
        base.Update();
        // �R���C�_�[�����ǂ����Ŕ��肷��
        if (Input.GetMouseButton(0) && IsMouseInsideCollider())
        {
            // �㉺����ŁA�I�u�W�F�N�g�̒��S���㉺�����ɒʂ�߂�����_���[�W
            if (_isUnder != Camera.main.WorldToScreenPoint(transform.position).y >= ((Vector2)Input.mousePosition).y)
            {
                // �㉺���]
                _isUnder = !_isUnder;

                if (Time.timeScale != 0f)
                {
                    soundManager.PlaySE(_hpSE);
                    _hp--;
                }
                // HP��0�ɂȂ�����L�����N�^�[������
                if (_hp <= 0)
                {
                    soundManager.StopSound();
                    Die();
                }
            }
        }
    }

    // �R���C�_�[�Ȃ��Ƀ}�E�X�����邩�̔���
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
