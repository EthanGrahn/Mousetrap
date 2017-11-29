using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float patrolDist = 5;
    public float patrolSpeed = 4;
    public bool xPlane = true;

    Vector3 startPos;
    Vector3 right, left;
    bool travRight = true;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        if (xPlane)
        {
            right = new Vector3(startPos.x + patrolDist, startPos.y, startPos.z);
            left = new Vector3(startPos.x - patrolDist, startPos.y, startPos.z);
        }
        else
        {
            right = new Vector3(startPos.x, startPos.y, startPos.z + patrolDist);
            left = new Vector3(startPos.x, startPos.y, startPos.z - patrolDist);
        }
        StartCoroutine("Patrol");
	}

    IEnumerator Patrol()
    {
        //Debug.Log("Patrol start");
        while (gameObject.activeInHierarchy) // && !rightCollide
        {
            if (xPlane)
            {
                while (transform.position.x < right.x)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                while (transform.position.x > left.x) // && !leftCollide
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(-patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
            }
            else
            {
                while (transform.position.z < right.z)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                while (transform.position.z > left.z) // && !leftCollide
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, -patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
            }
            yield return null;
        }
        //Debug.Log("Patrol end");
    }

    bool CheckRaycast()
    {
        return Physics.Raycast(transform.position, transform.right) || Physics.Raycast(transform.position, -transform.right);
    }
}
