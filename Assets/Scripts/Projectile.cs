using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;      
    public float forceAmount = 25f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 forceDirection = transform.forward;
        rigidbody.AddForce(forceDirection * forceAmount, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {
        //print($"Collides with {other.gameObject.name}");
        if (other.gameObject.CompareTag("Castle"))
        {
            //Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Barrel"))
        {
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
