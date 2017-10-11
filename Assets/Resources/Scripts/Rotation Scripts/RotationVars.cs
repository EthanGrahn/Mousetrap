using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVars : MonoBehaviour {

	public enum rotationDirection { left = 90, right = -90 };
    public rotationDirection rotationDir;
    public PositionStates.Rotation endingRotation;
    public PositionStates.Direction endingDirection;
}
