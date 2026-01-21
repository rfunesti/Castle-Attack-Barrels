using UnityEngine;
// NOTE: THIS SCRIPT IS ATTACHED TO THE ROTATE OBJECT OF THE CANNON PREFAB

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform fireSocket;
    public Animator animator;
    public ParticleSystem fireFX;
    public float rotationRate = 90.0f;
    public int numProjectiles = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        //Debug.Log($"aimInput: {aimInput}");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Fire();
            
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        fireFX.Play();
        numProjectiles++;
    }
}
