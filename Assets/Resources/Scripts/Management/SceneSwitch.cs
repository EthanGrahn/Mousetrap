using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    /// <summary>
    /// Switch scene to scene at specified index in build.
    /// </summary>
    /// <param name="sceneIndex">index in build</param>
    public void ChangeLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Switch scene to scene with specified name.
    /// </summary>
    /// <param name="sceneName">scene name</param>
    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Exit currently running game instance.
    /// </summary>
    /// <remarks>Does not work in editor.</remarks>
    public void ExitGame()
    {
        Application.Quit();
    }
}
