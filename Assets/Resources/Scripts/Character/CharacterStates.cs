﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterStates {
    void Update( );
    void FixedUpdate( );
    void SwitchToRotation( );
    void SwitchToPlayerMovement( );
    void SwitchToPlayerCrawl( );
    void OnTriggerEnter( Collider other );
}
