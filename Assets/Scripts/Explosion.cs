using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force, radius, modifier;
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        //Debug.Log(explosionFX.name + transform.position + gameObject.name);
        Invoke("DestroyExplosion", 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
    }
  
    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
