using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("敵の出現数")] private int _enemyAmount = 1;
    [SerializeField, Header("敵の出現間隔")] private float _appearTime = 2;
    [SerializeField, Header("各EnemyManagerごとのラグ")] private float _appearLag;
    private float _appearTimeCount;

    [SerializeField, Header("敵")] private GameObject[] _enemies;

    [SerializeField, Header("Minの値とMaxの値をVectorでやってる？")] private Vector2 _generatePosX;
    [SerializeField, Header("Minの値とMaxの値をVectorでやってる？")] private Vector2 _generatePosY;

    [SerializeField] private Transform _playerTrans;
    private Vector2 _playerPos => _playerTrans.position;

    [SerializeField, Header("プレイヤーの範囲")] private float _playerDistance;

    // 敵のIDのカウント
    private int _currentEnemyID = 0;

    private void Awake()
    {
        _playerTrans = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        _appearTimeCount = 0;
        StartCoroutine(EnemyAppearCoroutine());
    }

    private void Update()
    {
        EnemyAppear();
    }

    private void EnemyAppear()
    {
        _appearTimeCount += Time.deltaTime;

        if (_appearTimeCount > _appearTime)
        {
            StartCoroutine(EnemyAppearCoroutine());
            _appearTimeCount = 0;
        }
    }

    private IEnumerator EnemyAppearCoroutine()
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

            // 敵キャラクターを生成
            var enemyObject = Instantiate(_enemies[enemyRnd], posRnd, Quaternion.identity);

            // 敵キャラクターにIDを設定していく,AttackPlayerクラスで保持
            var enemyComponent = enemyObject.GetComponent<AttackPlayer>();
            if (enemyComponent != null)
            {
                enemyComponent.ID = _currentEnemyID;
                _currentEnemyID++; 
            }

            yield return new WaitForSeconds(_appearLag);
        }
    }

    //Editor拡張
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_playerPos, _playerDistance);
    }
}
