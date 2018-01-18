using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpManager : MonoBehaviour {
    public Vector3 currCheckpoint;
<<<<<<< HEAD
    public CharacterMovement player;
=======
<<<<<<< HEAD
    private CharacterMovement player;
=======
    public CharacterMovement player;
>>>>>>> ekgrahn-working
>>>>>>> ndcregut-working

    void Awake( ) {
        player = GameManager.Instance.CharMovement;
        if (player)
            currCheckpoint = player.transform.position;
    }

    public void ResetPlayer( ) {
<<<<<<< HEAD
        if (!player)
            player = GameManager.Instance.CharMovement;

=======
<<<<<<< HEAD
=======
        if (!player)
            player = GameManager.Instance.CharMovement;

>>>>>>> ekgrahn-working
>>>>>>> ndcregut-working
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
        player.transform.position = currCheckpoint;
        Debug.Log( "Got into reset player" + currCheckpoint + player.transform.position + player.name );
    }
}
