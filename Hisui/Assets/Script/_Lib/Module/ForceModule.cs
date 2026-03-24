using UnityEngine;

public class ForceModule : MonoBehaviour
{
    [SerializeField] float speed = 7f;

    [SerializeField] Transform targets;

    Rigidbody2D rb2;

    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
