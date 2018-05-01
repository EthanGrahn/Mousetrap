using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraState
{
    public GameObject objToFollow = null;
    public float speed = -1;
    public float camViewInFront = -1;
    public float camViewAbove = -1;
    public float minMoveDistHor = -1;
    public float minMoveDistVer = -1;
    public float distFromObj = -1;
    public float timeToUpdate = -1;


    public CameraState() { }
    public CameraState(GameObject _objToFollow, float _speed, float _camViewInFront, float _camViewAbove, float _minMoveDistHor,
        float _minMoveDistVer, float _distFromObj, float _timeToUpdate)
    {
        objToFollow = _objToFollow;
        speed = _speed;
        camViewInFront = _camViewInFront;
        camViewAbove = _camViewAbove;
        minMoveDistHor = _minMoveDistHor;
        minMoveDistVer = _minMoveDistVer;
        distFromObj = _distFromObj;
        timeToUpdate = _timeToUpdate;
    }

    public static bool operator ==(CameraState obj1, CameraState obj2)
    {
        return obj1.objToFollow == obj2.objToFollow &&
                obj1.speed == obj2.speed &&
                obj1.camViewInFront == obj2.camViewInFront &&
                obj1.camViewAbove == obj2.camViewAbove &&
                obj1.minMoveDistHor == obj2.minMoveDistHor &&
                obj1.minMoveDistVer == obj2.minMoveDistVer &&
                obj1.distFromObj == obj2.distFromObj &&
                obj1.timeToUpdate == obj2.timeToUpdate;
    }

    public static bool operator !=(CameraState obj1, CameraState obj2)
    {
        return obj1.objToFollow != obj2.objToFollow ||
                obj1.speed != obj2.speed ||
                obj1.camViewInFront != obj2.camViewInFront ||
                obj1.camViewAbove != obj2.camViewAbove ||
                obj1.minMoveDistHor != obj2.minMoveDistHor ||
                obj1.minMoveDistVer != obj2.minMoveDistVer ||
                obj1.distFromObj != obj2.distFromObj ||
                obj1.timeToUpdate != obj2.timeToUpdate;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((CameraState)obj);
    }

    public override int GetHashCode()
    {
        return objToFollow.GetHashCode() ^ speed.GetHashCode() ^ camViewInFront.GetHashCode() ^ camViewAbove.GetHashCode()
             ^ minMoveDistHor.GetHashCode() ^ minMoveDistVer.GetHashCode() ^ distFromObj.GetHashCode() ^ timeToUpdate.GetHashCode();
    }
}
