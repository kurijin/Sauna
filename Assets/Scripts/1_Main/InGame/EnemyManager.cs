using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("敵の出現数")]
    private int _enemyAmount = 1;

    /// <summary>
    /// 敵出現数のセッター
    /// </summary>
    /// <param name="amount"></param>
    public void SetEnemyAmount(int amount)
    {
        _enemyAmount = amount;
    }

    [SerializeField, Header("敵の出現間隔")]
    private float _apperTime = 2;

    /// <summary>
    /// 敵出現間隔のセッター
    /// </summary>
    /// <param name="apperTime"></param>
    public void SetApperTime(float apperTime)
    {
        _apperTime = apperTime;
    }

    [SerializeField]
    private float _apperLag = 0;

    public void SetApperLag(float apperLag)
    {
        _apperLag = apperLag;
    }

    private float _apperTimeCount = 0;

    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private Vector2 _generatePosX;

    [SerializeField]
    private Vector2 _generatePosY;

    [SerializeField]
    private Transform _playerTrans;

    private Vector2 _playerPos => _playerTrans.position;

    [SerializeField,Header("プレイヤーの範囲")]
    private float _playerDistance;

    private void Awake()
    {
        _playerTrans = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        _apperTimeCount = 0;
        StartCoroutine(EnemyApperCoroutine());
    }

    private void Update() 
    {
        EnemyApper();
    }

    private void EnemyApper()
    {
        _apperTimeCount += Time.deltaTime;

        if(_apperTimeCount > _apperTime)
        {
            StartCoroutine(EnemyApperCoroutine());
            _apperTimeCount = 0;
        }   
    }

    private IEnumerator EnemyApperCoroutine()
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            var num = _enemies.Length;
            var enemyRnd = Random.Range(0, num);
            var posRnd = Vector2.zero;
            posRnd.x = Random.Range(_generatePosX.x, _generatePosX.y);
            posRnd.y = Random.Range(_generatePosY.x, _generatePosY.y);

            if (Vector2.Distance(posRnd, _playerPos) < _playerDistance)
            {
                i--;
                continue;
            }

            Instantiate(_enemies[enemyRnd], posRnd, Quaternion.identity);

            yield return new WaitForSeconds(_apperLag);
        }
    }

    private IEnumerator EnemyApperLag()
    {
        yield return new WaitForSeconds(_apperLag);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_playerPos, _playerDistance);
    }
}
