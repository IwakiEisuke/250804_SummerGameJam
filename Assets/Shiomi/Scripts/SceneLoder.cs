using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    /// <summary>
    /// シーンのロード
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
