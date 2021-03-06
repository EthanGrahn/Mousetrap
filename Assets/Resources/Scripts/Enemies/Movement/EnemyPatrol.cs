﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Patroling logic for spider enemy.
/// </summary>
public class EnemyPatrol : MonoBehaviour
{
    public float patrolDist = 5;
    public float patrolSpeed = 3;
    public float playerCheckDist = 10;
    public float chaseSpeed = 5;
    public float chaseDist = 10;
    public bool xPlane = true;
    public float wDropStart = 2;
    public float wDropEnd = 8;
    public GameObject webPrefab;
    public SpriteRenderer spriteRenderer;

    Vector3 startPos;
    Vector3 right, left;
    Vector3 rCast, lCast;
    Vector3 castPosTop, castPosBot;
    Vector3 ledgeCheckPosition, ledgeCheckNew;
    Vector3 chaseRightPos;
    Vector3 chaseLeftPos;
    bool travRight = true;
    bool prevTravel = true;
    int layermask;
    float wDropTime;

    /// <summary>
    /// Unity initialization.
    /// </summary>
    void Start()
    {
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
        ledgeCheckPosition = transform.GetChild(0).position;

        StartCoroutine("Patrol");
        StartCoroutine("PlayerChecking");
        StartCoroutine("WebDrop");
    }

    /// <summary>
    /// Unity method to draw gizmo when object is selected.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            startPos = transform.position;
            if (xPlane)
            {
                right = new Vector3(startPos.x + patrolDist, startPos.y, startPos.z);
                left = new Vector3(startPos.x - patrolDist, startPos.y, startPos.z);
                chaseRightPos = new Vector3(right.x + chaseDist, right.y, right.z);
                chaseLeftPos = new Vector3(left.x - chaseDist, left.y, left.z);
            }
            else
            {
                right = new Vector3(startPos.x, startPos.y, startPos.z + patrolDist);
                left = new Vector3(startPos.x, startPos.y, startPos.z - patrolDist);
                chaseRightPos = new Vector3(right.x, right.y, right.z + chaseDist);
                chaseLeftPos = new Vector3(left.x, left.y, left.z - chaseDist);
            }
        }
        Gizmos.color = Color.white;
        Gizmos.DrawLine(left, right);
        Gizmos.DrawLine(new Vector3(left.x, left.y + 0.5f, left.z), new Vector3(left.x, left.y - 0.5f, left.z));
        Gizmos.DrawLine(new Vector3(right.x, right.y + 0.5f, right.z), new Vector3(right.x, right.y - 0.5f, right.z));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(chaseLeftPos, left);
        Gizmos.DrawLine(chaseRightPos, right);
        Gizmos.DrawLine(new Vector3(chaseLeftPos.x, chaseLeftPos.y + 0.5f, chaseLeftPos.z), new Vector3(chaseLeftPos.x, chaseLeftPos.y - 0.5f, chaseLeftPos.z));
        Gizmos.DrawLine(new Vector3(chaseRightPos.x, chaseRightPos.y + 0.5f, chaseRightPos.z), new Vector3(chaseRightPos.x, chaseRightPos.y - 0.5f, chaseRightPos.z));
    }

    /// <summary>
    /// Waits for a range of time then drops the web trap prefab.
    /// </summary>
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

    /// <summary>
    /// Performs distance checks from enemy object to player object.
    /// </summary>
    IEnumerator PlayerChecking()
    {
        yield return new WaitForFixedUpdate();
        float initSpeed = patrolSpeed;
        Vector3 initRightPos = right;
        Vector3 initLeftPos = left;

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

    /// <summary>
    /// Perform movement for the enemy player along with collision detection.
    /// </summary>
    IEnumerator Patrol()
    {
        //Debug.Log("Patrol start");
        int invalid = 0;
        float position;
        while (gameObject.activeInHierarchy)
        {
            if (xPlane)
            {
                travRight = true;
                invalid = 0;
                position = transform.position.x;
                spriteRenderer.flipX = true;
                while (transform.position.x < right.x && !CheckCollision(2) && invalid < 10)
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                    if (transform.position.x == position)
                    {
                        invalid++;
                    }

                    position = transform.position.x;
                }
                invalid = 0;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                travRight = false;
                spriteRenderer.flipX = false;
                while (transform.position.x > left.x && !CheckCollision(2) && invalid < 10)
                {
                    position = transform.position.x;
                    GetComponent<Rigidbody>().velocity = new Vector3(-patrolSpeed, GetComponent<Rigidbody>().velocity.y, 0);
                    yield return new WaitForFixedUpdate();
                    if (transform.position.x == position)
                    {
                        invalid++;
                    }

                    position = transform.position.x;
                }
            }
            else // (zPlane)
            {
                travRight = true;
                invalid = 0;
                position = transform.position.z;
                spriteRenderer.flipX = true;
                while (transform.position.z < right.z && !CheckCollision(2) && invalid < 10)
                {
                    position = transform.position.z;
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, patrolSpeed);
                    yield return new WaitForFixedUpdate();
                    if (transform.position.z == position)
                    {
                        invalid++;
                    }

                    position = transform.position.z;
                }
                invalid = 0;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                travRight = false;
                spriteRenderer.flipX = false;
                while (transform.position.z > left.z && !CheckCollision(2) && invalid < 10)
                {
                    position = transform.position.z;
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, -patrolSpeed);
                    yield return new WaitForFixedUpdate();
                    if (transform.position.z == position)
                    {
                        invalid++;
                    }

                    position = transform.position.z;
                }
            }
            yield return null;
        }
        //Debug.Log("Patrol end");
    }

    /// <summary>
    /// Checks for collisions with walls or ledges ahead of movement direction.
    /// </summary>
    /// <param name="distance">Distance to raycast for walls</param>
    /// <returns></returns>
    bool CheckCollision(float distance) // raycast left or right
    {
        castPosTop = new Vector3(transform.position.x, transform.position.y + (0.5f * GetComponent<SphereCollider>().radius), transform.position.z);
        castPosBot = new Vector3(transform.position.x, transform.position.y - (0.5f * GetComponent<SphereCollider>().radius) + GetComponent<SphereCollider>().radius, transform.position.z);

        if (travRight)
        {
            Transform child = transform.GetChild(0);
            if (prevTravel == travRight)
            {
                prevTravel = !prevTravel;
                if (xPlane)
                {
                    child.localPosition = new Vector3(Mathf.Abs(child.localPosition.x), child.localPosition.y, child.localPosition.z);
                }
                else
                {
                    child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y, Mathf.Abs(child.localPosition.z));
                }
            }
            ledgeCheckNew = child.position;

            float ledgeDistance = Vector3.Distance(this.transform.position, ledgeCheckNew);
            Vector3 ledgeDirection = (this.transform.position - ledgeCheckNew) / (this.transform.position - ledgeCheckNew).magnitude;
            //Debug.DrawLine(this.transform.position, ledgeCheckNew, Color.red, Time.deltaTime);
            bool ledge = !Physics.Linecast(this.transform.position, ledgeCheckNew, layermask);
            return Physics.Raycast(castPosTop, rCast, distance, layermask) || Physics.Raycast(castPosBot, rCast, distance, layermask) || ledge;
        }
        else
        {
            Transform child = transform.GetChild(0);
            if (prevTravel == travRight)
            {
                prevTravel = !prevTravel;
                if (xPlane)
                {
                    child.localPosition = new Vector3(-child.localPosition.x, child.localPosition.y, child.localPosition.z);
                }
                else
                {
                    child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y, -child.localPosition.z);
                }
            }
            ledgeCheckNew = child.position;

            float ledgeDistance = Vector3.Distance(this.transform.position, ledgeCheckNew);
            Vector3 ledgeDirection = (this.transform.position - ledgeCheckNew) / (this.transform.position - ledgeCheckNew).magnitude;
            //Debug.DrawLine(this.transform.position, ledgeCheckNew, Color.blue, Time.deltaTime);
            bool ledge = !Physics.Linecast(this.transform.position, ledgeCheckNew, layermask);//!Physics.Raycast(this.transform.position, ledgeDirection, ledgeDistance, layermask);
            return Physics.Raycast(castPosTop, lCast, distance, layermask) || Physics.Raycast(castPosBot, lCast, distance, layermask) || ledge;
        }
    }

    /// <summary>
    /// Check if the player is within the specified distance from this gameobject.
    /// </summary>
    /// <param name="distance">Minimum detection distance.</param>
    /// <returns>Whether player is within specified distance.</returns>
    bool CheckForPlayer(float distance)
    {
        return Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) <= distance;
    }
}
