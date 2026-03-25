using UnityEngine;

public class RandDirForce : MonoBehaviour
{
    [SerializeField] float speed = 7f;

    [SerializeField] Transform targets;

    Rigidbody2D rb2;

    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));

        rb2 = GetComponent<Rigidbody2D>();

        direction = targets.position - transform.position;

        if (rb2 != null)
            rb2.linearVelocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb2 != null)
        //    rb2.linearVelocity = direction.normalized * speed;
    }
}
