using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpManager : MonoBehaviour {
    public Vector3 currCheckpoint;
    public GameObject player;

    void Awake( ) {
        player = GameManager.Instance.Player;
        if (player)
             currCheckpoint = player.transform.position;
    }

    public void ResetPlayer( ) {
        if (!player)
            player = GameManager.Instance.Player;
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        player.transform.position = currCheckpoint;
        //Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }
}
