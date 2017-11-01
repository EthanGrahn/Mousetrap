using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpManager : MonoBehaviour {
    public Vector3 currCheckpoint;
    public GameObject player;

    void Awake( ) {
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        currCheckpoint = player.transform.position;
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }

    public void ResetPlayer( ) {
        player.transform.position = currCheckpoint;
    }
}
