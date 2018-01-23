using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float patrolDist = 5;
    public float patrolSpeed = 3;
    public float playerCheckDist = 10;
    public float chaseSpeed = 5;
    public float chaseDist = 10;
    public bool xPlane = true;
    public float wDropStart = 2;
    public float wDropEnd = 8;
    public GameObject webPrefab;

    Vector3 startPos;
    Vector3 right, left;
    Vector3 rCast, lCast;
    Vector3 castPosTop, castPosBot;
    bool travRight = true;
    int layermask;
    float wDropTime;

	// Use this for initialization
	void Start () {
        layermask = ~(1 << LayerMask.NameToLayer("EnemyTrap") | 1 << LayerMask.NameToLayer("Player"));
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

        wDropTime = Random.Range(wDropStart, wDropEnd);

        StartCoroutine("Patrol");
        StartCoroutine("PlayerChecking");
        StartCoroutine("WebDrop");
	}

    IEnumerator WebDrop()
    {
        bool dropped = false;
        float startTime = Time.time;
        while (!dropped)
        {
            yield return new WaitForFixedUpdate();
            if (Time.time - startTime >= wDropTime)
            {
                dropped = true;
                GameObject tmp = Instantiate(webPrefab);
                tmp.transform.localPosition = transform.position;
                tmp.transform.localRotation = transform.rotation;
                //Debug.Log("Dropped -- " + tmp.transform.position);
            }
        }
    }

    IEnumerator PlayerChecking()
    {
        yield return new WaitForFixedUpdate();
        float initSpeed = patrolSpeed;
        Vector3 initRightPos = right;
        Vector3 initLeftPos = left;
        Vector3 chaseRightPos;
        Vector3 chaseLeftPos;

        if (xPlane)
        {
            chaseRightPos = new Vector3(right.x + chaseDist, right.y, right.z);
            chaseLeftPos = new Vector3(left.x - chaseDist, left.y, left.z);
        }
        else // (zPlane)
        {
            chaseRightPos = new Vector3(right.x, right.y, right.z + chaseDist);
            chaseLeftPos = new Vector3(left.x, left.y, left.z - chaseDist);
        }

        while (gameObject.activeInHierarchy)
        {
            if (CheckForPlayer(playerCheckDist))
            {
                right = chaseRightPos;
                left = chaseLeftPos;
                patrolSpeed = chaseSpeed;
            }
            else
            {
                right = initRightPos;
                left = initLeftPos;
                patrolSpeed = initSpeed;
            }
                
            yield return new WaitForSeconds(1);
        }
        patrolSpeed = initSpeed;
    }

    IEnumerator Patrol()
    {
        //Debug.Log("Patrol start");
        while (gameObject.activeInHierarchy)
        {
            if (xPlane)
            {
                travRight = true;
                while (transform.position.x < right.x && !CheckCollision(2))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                travRight = false;
                while (transform.position.x > left.x && !CheckCollision(2))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(-patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                }
            }
            else // (zPlane)
            {
                travRight = true;
                while (transform.position.z < right.z && !CheckCollision(2))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                travRight = false;
                while (transform.position.z > left.z && !CheckCollision(2))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, -patrolSpeed);
                    yield return new WaitForFixedUpdate();
                }
            }
            yield return null;
        }
        //Debug.Log("Patrol end");
    }

    bool CheckCollision(float distance) // raycast left or right
    {
        castPosTop = new Vector3(transform.position.x, transform.position.y + (0.5f * GetComponent<CapsuleCollider>().height), transform.position.z);
        castPosBot = new Vector3(transform.position.x, transform.position.y - (0.5f * GetComponent<CapsuleCollider>().height) + GetComponent<CapsuleCollider>().radius, transform.position.z);
        
        if (travRight)
        {
            Debug.DrawRay(castPosTop, rCast * distance, Color.red, Time.deltaTime);
            Debug.DrawRay(castPosBot, rCast * distance, Color.red, Time.deltaTime);
            return Physics.Raycast(castPosTop, rCast, distance, layermask) || Physics.Raycast(castPosBot, rCast, distance, layermask);
        }
        else
        {
            return Physics.Raycast(castPosTop, lCast, distance, layermask) || Physics.Raycast(castPosBot, lCast, distance, layermask);
        }
    }

    bool CheckForPlayer(float distance) // check distance to player
    {
        return Vector3.Distance(GameManager.Instance.CharMovement.transform.position, transform.position) <= distance;
    }
}
