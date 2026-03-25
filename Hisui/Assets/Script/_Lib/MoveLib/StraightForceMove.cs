using UnityEngine;

public class StraightForceMove : BaseMove
{
    [SerializeField] float speed = 7f;

    [SerializeField] Transform targets;

    Rigidbody2D rb2;

    Vector3 direction;

    //public void SetTarget(Transform t)
    //{
    //    targets = t;
    //    direction = targets.position - transform.position;
    //    //targetDir = (targetsVec - transform.position).normalized;

    //    //Debug.Log("SetTarget");
    //}

    public override void Initialize()
    {
        base.Initialize();
        rb2 = GetComponent<Rigidbody2D>();

        direction = targets.position - transform.position;
    }

    public override void MoveEnter()
    {
        //var randf = Random.Range(0.3f, 1f);

        //direction.x += randf;
        if (rb2 != null)
            rb2.linearVelocity = direction.normalized * speed;
            //rb.AddForce(/*m_rb3.position + */direction.normalized * speed, ForceMode2D.Impulse);

    }

    public override void MoveUpdate()
    {
        //if (isRot)
        //RotUpdate();

        //AddForceに変更して　衝突座標からCollisionEnterで跳ね返る　VelocityChange?使用で　　MoveEnter??

        //if (m_rb != null)
        //    m_rb.MovePosition((Vector3)m_rb.position + direction.normalized * speed * Time.deltaTime);
        //else if (m_rb3 != null)
        //    m_rb3.MovePosition(m_rb3.position + direction.normalized * speed * Time.deltaTime);
        //else
        //    transform.position += direction.normalized * speed * Time.deltaTime;

        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

    //void RotUpdate()
    //{
    //    if (rotStopTime <= 0) return;
    //    rotStopTime -= Time.deltaTime;

    //    transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    //}

    //private void OnCollisionEnter(Collision other)
    //{

    //    var m_rb3 = GetComponent<Rigidbody>();
    //    //if (other.gameObject.tag == TagName.Player)
    //     //   Debug.Log(TagName.Player);

    //    const int BlockReflect = 23;
    //    if (other.gameObject.layer == BlockReflect)
    //    {
    //        m_rb3.angularVelocity = m_rb3.angularVelocity.normalized * speed;
    //        m_rb3.linearVelocity = m_rb3.linearVelocity.normalized * speed;
    //    }
    //}
}
