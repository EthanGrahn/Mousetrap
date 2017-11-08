using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionStates {
    public enum Rotation { zero = 0, one = 90, two = 180, three = 270 };
    public enum Direction { left = -1, right = 1, idle = 0 };

    /// <summary>
    /// Constrains the movement in z or x axis, depending on rotation, and rotation of the object in all axes.
    /// </summary>
    /// <param name="obj">Object to constrain movement on</param>
    /// <param name="currentRotation">Current Rotation of the object</param>
    public static void GetConstraints( GameObject obj, Rotation currentRotation ) {
        if ( currentRotation == Rotation.zero ||
            currentRotation == Rotation.two )
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        else
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
    }

    /// <summary>
    /// Constrains the movement in z or x axis, depending on rotation, and rotation of the object in certain axes.
    /// </summary>
    /// <param name="obj">Object to constrain movement on</param>
    /// <param name="currentRotation">Current Rotation of the object</param>
    public static void GetConstraintsRot(GameObject obj, Rotation currentRotation) {
        if ( currentRotation == Rotation.zero ||
            currentRotation == Rotation.two )
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        else
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
    }
}
