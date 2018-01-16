using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float patrolDist = 5;
    public float patrolSpeed = 4;
    public bool xPlane = true;

    Vector3 startPos;
    Vector3 right, left;
    Vector3 rCast, lCast;
    bool travRight = true;
    int layermask;

	// Use this for initialization
	void Start () {
        layermask = ~(1 << LayerMask.NameToLayer("EnemyTrap"));
        startPos = transform.position;
        if (xPlane)
        {
            right = new Vector3(startPos.x + patrolDist, startPos.y, startPos.z);
            left = new Vector3(startPos.x - patrolDist, startPos.y, startPos.z);
            rCast = new Vector3(1, 0, 0);
            lCast = -rCast;
        }
        else
        {
            right = new Vector3(startPos.x, startPos.y, startPos.z + patrolDist);
            left = new Vector3(startPos.x, startPos.y, startPos.z - patrolDist);
            rCast = new Vector3(0, 0, 1);
            lCast = -rCast;
        }
        StartCoroutine("Patrol");
	}

    IEnumerator Patrol()
    {
        //Debug.Log("Patrol start");
        while (gameObject.activeInHierarchy)
        {
            if (xPlane)
            {
                while (transform.position.x < right.x && !CheckCollision(true))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                while (transform.position.x > left.x && !CheckCollision(false))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(-patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
            }
            else // (zPlane)
            {
                while (transform.position.z < right.z && !CheckCollision(true))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                while (transform.position.z > left.z && !CheckCollision(false))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, -patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
            }
            yield return null;
        }
        //Debug.Log("Patrol end");
    }

    bool CheckCollision(bool movingRight)
    {
        if (movingRight)
            return Physics.Raycast(transform.position, rCast, 2, layermask);
        else
            return Physics.Raycast(transform.position, lCast, 2, layermask);
    }
}
