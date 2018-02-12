using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpObject : MonoBehaviour {
    public bool enemy;
    void OnTriggerEnter( Collider other ) {
        if (other.CompareTag("Player")) {
            if ( enemy ) {
                GameManager.Instance.cpManager.ResetPlayer( );
            } else {
                GameManager.Instance.cpManager.currCheckpoint = gameObject.transform.position;
            }
        }
    }
}
