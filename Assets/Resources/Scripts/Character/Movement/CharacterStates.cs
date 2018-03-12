using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterStates {
    void Update( );
    void FixedUpdate( );
    void OnTriggerEnter( Collider other );
    void OnTriggerExit( Collider other );
    void OnTriggerStay( Collider other );
    void SwitchToPlayerMovement( );
    void SwitchToPlayerClimb( );
}
