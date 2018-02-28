using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpObject : MonoBehaviour {

    public enum cpType{
        enemy,
        checkpoint
    }

    public cpType objectType = cpType.checkpoint;
    void OnTriggerEnter( Collider other ) {
        if (other.CompareTag("Player")) {
            if ( objectType == cpType.enemy ) {
                GameManager.Instance.cpManager.ResetPlayer( );
            } else {
                GameManager.Instance.cpManager.currCheckpoint = gameObject.transform.position;
            }
        }
    }
}
