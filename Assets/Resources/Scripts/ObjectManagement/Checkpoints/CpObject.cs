using UnityEngine;

public class CpObject : MonoBehaviour
{
    public enum cpType
    {
        enemy,
        checkpoint
    }

    public cpType objectType = cpType.checkpoint;

    /// <summary>
    /// Unity even called when object enters attached trigger collider.
    /// </summary>
    /// <param name="other">The other objects collider data</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectType == cpType.enemy)
            {
                GameManager.Instance.cpManager.ResetPlayer();
            }
            else
            {
                GameManager.Instance.cpManager.currCheckpoint = gameObject.transform.position;
            }
        }
    }
}
