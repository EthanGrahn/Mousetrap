using UnityEngine;
using UnityEngine.SceneManagement;

public class CpManager : MonoBehaviour
{
    public Vector3 currCheckpoint;
    public GameObject player;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Unity event called when scene is loaded.
    /// </summary>
    /// <param name="scene">Scene data</param>
    /// <param name="mode">Mode in which the scene was loaded</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Office Level")
        {
            player = GameManager.Instance.Player;
            currCheckpoint = player.transform.position;
        }
    }

    /// <summary>
    /// Return player object back to the previous checkpoint.
    /// </summary>
    public void ResetPlayer()
    {
        if (!player)
        {
            player = GameManager.Instance.Player;
        }
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        player.transform.position = currCheckpoint;
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }
}
