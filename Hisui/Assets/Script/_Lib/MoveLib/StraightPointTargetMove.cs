using System.Collections.Generic;
using UnityEngine;

//地面の衝突判定　設定した時間で破棄（衝突しないとき用）　プレイヤーがSTARTLEN以内に入ったら移動開始 
public class StraightPointTargetMove : BaseMove
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] float STARTLEN = 3f;

    [SerializeField] protected List<Transform> moveTransLists = new();
    protected float ENDMOVELEN = 0.7f;


    protected int targetNo = 0;

    protected Vector3 direction;

    //protected ReactiveProperty<bool> IsMoveEnd = new ReactiveProperty<bool>(false);

    protected TargetSet targetSet;

    Transform player=null;
    bool isStart = false;


    public override void Initialize()
    {
        if (gameObject.GetComponent<TargetSet>()!=null)
        {
            targetSet = GetComponent<TargetSet>();
            moveTransLists = targetSet.SetPointArray(moveTransLists);
        }

        direction = (moveTransLists[targetNo].position - transform.position).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        if (!MoveStart()) return;

        //指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;

        float len = Vector3.Distance(transform.position, moveTransLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;


        //最後の移動地点へ到着したら
        if (targetNo == moveTransLists.Count - 1)
        {
            //IsMoveEnd.Value = true;

        }
        else
        {
            targetNo++;
            direction = (moveTransLists[targetNo].position - transform.position).normalized;
        }

    }


    bool MoveStart()
    {
        if (isStart) return true;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            Debug.Log("プレイヤーが存在しない");
            return isStart;
        }

        float sLen = Vector3.Distance(transform.position, player.position);
        if (sLen > STARTLEN)
        {
            MyLib.DebugInfo(gameObject);
            Debug.Log("プレイヤーが離れている");
            return isStart;
        }

        //オブジェクトにTimeDestroyコンポーネントが必要
        GetComponent<TimeDestroy>().SetTime();
        isStart = true;
        return isStart;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            Destroy(gameObject);
            Debug.Log("地面に衝突して消滅");
        }

    }

}
