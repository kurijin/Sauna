# g2-intern-202408-02
夏期インターン用リポジトリ0821-23

# Git
## branch規則
name/function

# Unity
## TimeScore - クリアタイムの管理
値の保存：TimeScore.Instance.SaveTime(float);

値の取得：var hoge = TimeScore.Instance.GetTime();

## SceneChanger - シーン遷移管理
タイトルシーンへ：SceneChanger.Instance.ToTitleScene();

メインシーンへ：SceneChanger.Instance.ToMainScene();

リザルトシーンへ：SceneChanger.Instance.ToResultScene();

## Attribute
### SerializeField - Inspectorで操作可能な変数
[SerializeField]
private float time;

### ReadOnly - Inspectorで操作不可能な変数
[SerializeField, ReadOnly]
private float time;
