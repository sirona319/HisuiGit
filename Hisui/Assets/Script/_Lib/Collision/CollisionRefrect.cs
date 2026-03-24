using UnityEngine;

//https://feynman.co.jp/unityforest/unity-introduction/breakout-making/

public class CollisionRefrect : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        const int BlockReflect = 23;
        if (other.gameObject.layer == BlockReflect)
            rb.linearVelocity = rb.linearVelocity.normalized * speed;

    }

}
