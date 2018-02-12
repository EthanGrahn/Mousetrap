using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionStates {
    public enum Rotation { xPos = 1, zPos = 2, xNeg = -1, zNeg = -2 };
    public enum Direction { left = -1, right = 1, idle = 0 };

    /// <summary>
    /// Constrains the movement in z or x axis, depending on rotation, and rotation of the object in all axes.
    /// </summary>
    /// <param name="obj">Object to constrain movement on</param>
    /// <param name="currentRotation">Current Rotation of the object</param>
    public static void GetConstraints( GameObject obj, Rotation currentRotation ) {
        if ( currentRotation == Rotation.xPos ||
            currentRotation == Rotation.xNeg )
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
        if ( currentRotation == Rotation.xPos ||
            currentRotation == Rotation.xNeg )
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        else
            obj.GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
    }

    /// <summary>
    /// Is moving from "fromRotation" to "toRotation" rotating clockwise?
    /// </summary>
    /// <param name="fromRotation">Starting rotation</param>
    /// <param name="toRotation"Ending rotation></param>
    /// <returns>True if clockwise, false if counter-clockwise.</returns>
    public static bool IsClockwise(Rotation fromRotation, Rotation toRotation)
    {
        return (fromRotation == Rotation.xPos && toRotation == Rotation.zNeg) ||
               (fromRotation == Rotation.zNeg && toRotation == Rotation.xNeg) ||
               (fromRotation == Rotation.xNeg && toRotation == Rotation.zPos) ||
               (fromRotation == Rotation.zPos && toRotation == Rotation.xPos);
    }
}
