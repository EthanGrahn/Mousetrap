using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chewable : MonoBehaviour {

    int mashes;
    int mashCount = 0;

    // Use this for initialization
    void Start () {
        mashes = Random.Range(8, 16);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Rebind.GetInputDown("Interact"))
            mashCount++;

        if (mashCount >= mashes)
            Destroy(this.gameObject);
    }
}
