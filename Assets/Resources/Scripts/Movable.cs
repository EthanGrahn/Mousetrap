using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines properties of an object able to be moved.
/// </summary>
[RequireComponent(typeof(ObjectProperties))]
public class Movable : MonoBehaviour
{

    public enum MovablePlane
    {
        x_Plane,
        z_Plane
    }

    public MovablePlane planeOfMotion = MovablePlane.x_Plane;
    public float forceMultiplier = 8;

    private new Rigidbody rigidbody;
    private float startRot;
    private float startPos;
    private bool rCollision = false;
    private bool lCollision = false;

    /// <summary>
    /// Initialization.
    /// </summary>
    void Start()
    {
        if (GetComponent<Rigidbody>() == null)
            gameObject.AddComponent<Rigidbody>();

        rigidbody = GetComponent<Rigidbody>();
        startRot = transform.rotation.eulerAngles.y;

        if (planeOfMotion == MovablePlane.x_Plane)
            startPos = transform.position.z;
        else
            startPos = transform.position.x;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, startRot, transform.rotation.z);

        if (planeOfMotion == MovablePlane.x_Plane)
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos);
        else
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);

        CheckCollision();
        
        if ((planeOfMotion == MovablePlane.x_Plane && transform.InverseTransformDirection(rigidbody.velocity).x > 0.01f) ||
            (planeOfMotion == MovablePlane.z_Plane && transform.InverseTransformDirection(rigidbody.velocity).z > 0.01f))
            UpdateMovability(!rCollision);
        else if ((planeOfMotion == MovablePlane.x_Plane && transform.InverseTransformDirection(rigidbody.velocity).x < -0.01f) ||
                 (planeOfMotion == MovablePlane.z_Plane && transform.InverseTransformDirection(rigidbody.velocity).z < -0.01f))
            UpdateMovability(!lCollision);
        else
        {
            UpdateMovability(true);
        }
    }

    /// <summary>
    /// Do raycasts to check if object can be pushed left or right.
    /// </summary>
    private void CheckCollision()
    {
        Ray r_ray, l_ray;
        RaycastHit[] r_hit, l_hit;
        if (planeOfMotion == MovablePlane.x_Plane)
        {
            r_ray = new Ray(transform.position, Vector3.right);
            l_ray = new Ray(transform.position, -Vector3.right);
        }
        else
        {
            r_ray = new Ray(transform.position, Vector3.forward);
            l_ray = new Ray(transform.position, -Vector3.forward);
        }

        Debug.DrawRay(transform.position, Vector3.right * 2, Color.red);
        Debug.DrawRay(transform.position, -Vector3.right * 2, Color.red);

        r_hit = Physics.RaycastAll(r_ray, 1.1f);
        l_hit = Physics.RaycastAll(l_ray, 1.1f);
        
        for (int i = 0; i < r_hit.Length; ++i)
        {
            if (r_hit[i].collider.GetComponent<ObjectProperties>() != null &&
                !r_hit[i].collider.GetComponent<ObjectProperties>().GetBoolProperty("movable"))
            {
                rCollision = false;
            }
            else
            {
                rCollision = true;
            }
        }

        for (int i = 0; i < l_hit.Length; ++i)
        {
            if (l_hit[i].collider.GetComponent<ObjectProperties>() != null &&
                !l_hit[i].collider.GetComponent<ObjectProperties>().GetBoolProperty("movable"))
            {
                lCollision = false;
            }
            else
            {
                lCollision = true;
            }
        }
    }

    /// <summary>
    /// Update the Object Property component value of movability.
    /// </summary>
    /// <param name="movable">Is this object movable?</param>
    void UpdateMovability(bool movable)
    {
        int value = 0;
        if (movable)
            value = 1;
        GetComponent<ObjectProperties>().SetProperty("movable", value.ToString());
    }
}
