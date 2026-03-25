using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RandomMove : BaseMove
{
    [SerializeField] TilemapCollider2D tileCol;

    [SerializeField] Vector3[] movePos;
    [SerializeField] Vector3 targetPos;

    float moveRangeXZ = 3;
    const float ENDMOVELEN = 1f;

    float speed = 4;

    [SerializeField] Rigidbody2D rb2;

    public override void Initialize()
    {
        base.Initialize();


        movePos = new Vector3[4];

        movePos[0] = transform.position;
        movePos[0].x += moveRangeXZ;
        movePos[1] = transform.position;
        movePos[1].x -= moveRangeXZ;
        movePos[2] = transform.position;
        movePos[2].y += moveRangeXZ;
        movePos[3] = transform.position;
        movePos[3].y -= moveRangeXZ;
    }

    public override void MoveEnter()
    {
        MoveRandomSet();
    }

    public override void MoveUpdate()
    {
        Vector2 movement = targetPos.normalized * speed * Time.deltaTime;

        //Vector2 movement = transform.up * Time.deltaTime * speed;

        rb2.MovePosition(rb2.position + movement);

        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 5f);
        


        float len = Vector3.Distance(transform.position, targetPos);
        if (len < ENDMOVELEN)
            MoveRandomSet();            //移動地点の再設定
        
    }

    //時間でリセットするようにもする？
    void MoveRandomSet()
    {
        var moveRandomValue = Random.Range(0, movePos.Length);

        targetPos =
        movePos[moveRandomValue] + new Vector3
        (Random.Range(-moveRangeXZ, moveRangeXZ),
        Random.Range(-moveRangeXZ, moveRangeXZ),
        0);

        //GroundOutCheck(targetPos);
    }

    void GroundOutCheck(Vector3 pos)
    {
        if(Physics.OverlapSphere(pos, 0).Any(col => col == tileCol))
        {
            // コライダーの中にある
            Debug.Log("コライダー内");
        }
        else
        {
            // コライダーの外にある
            Debug.Log("外");
        }
    }


}
