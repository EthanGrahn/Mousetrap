using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CpManager : MonoBehaviour {
    public Vector3 currCheckpoint;
    public GameObject player;

    void Start( ) {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ( scene.name == "Office Level" )
        {
            player = GameManager.Instance.Player;
            currCheckpoint = player.transform.position;
        }
    }

    public void ResetPlayer( ) {
        if (!player)
            player = GameManager.Instance.Player;
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        player.transform.position = currCheckpoint;
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }
}
