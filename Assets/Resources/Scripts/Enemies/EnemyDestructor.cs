using UnityEngine;

public class EnemyDestructor : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
                Destroy(collision.gameObject);
        }
    }
}
