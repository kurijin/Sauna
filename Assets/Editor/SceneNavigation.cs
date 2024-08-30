using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

//MenuバーにSceneを表示
public class SceneNavigation : Editor
{
    [MenuItem("Scene/TitleScene")]
    public static void OpenScene0()
    {
        EditorSceneManager.SaveOpenScenes();
        OpenScene(0);
    }

    [MenuItem("Scene/MainScene")]
    public static void OpenScene1()
    {
        EditorSceneManager.SaveOpenScenes();
        OpenScene(1);
    }
    
    [MenuItem("Scene/ResultScene")]
    public static void OpenScene2()
    {
        EditorSceneManager.SaveOpenScenes();
        OpenScene(2);
    }
    
    //シーンを保存して指定したシーンに遷移する
    private static void OpenScene(int sceneIndex)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
        if (!string.IsNullOrEmpty(scenePath))
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}
