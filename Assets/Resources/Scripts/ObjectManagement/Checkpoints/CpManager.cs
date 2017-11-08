using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpManager : MonoBehaviour {
    public Vector3 currCheckpoint;
    private CharacterMovement player;

    void Awake( ) {
        player = GameManager.Instance.CharMovement;
        if (player)
            currCheckpoint = player.transform.position;
    }

    public void ResetPlayer( ) {
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        player.transform.position = currCheckpoint;
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }
}
