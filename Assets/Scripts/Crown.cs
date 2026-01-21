using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // returns the first active loaded object of Type
            Score score = FindObjectOfType<Score>(); // <> brackets indicate generics (different types of variables)
            if (score)
            {
                score.EndLevel();
            }


            if (explosion)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
}
