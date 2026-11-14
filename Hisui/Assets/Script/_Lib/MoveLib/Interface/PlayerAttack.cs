//using UnityEngine;

//public interface PlayerAttack
//{
//    public Transform targetTrans;

//    Vector3[] moveVecter;
//    //Transform[] moveTrans;
//    int targetNo = 0;
//    const float ENDMOVELEN = 0.5f;

//    bool isAttackEnd = false;

//    public virtual void TargetSet(Transform t)
//    {
//        targetTrans = t;

//        if (moveVecter.Length <= 0)
//            throw new System.Exception( "ムーブポイント未設定");
//    }

//    public void Initialize()
//    {

//        moveVecter = new Vector3[2];

//    }

//    public virtual void MoveEnter()
//    {
//        moveVecter[0] = transform.position;
//        moveVecter[1] = targetTrans.position;
//        isAttackEnd = false;
//    }

//    public void MoveUpdate()
//    {
//        //if (!isMove)
//        //    return;

//        //var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
//        //m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);
//        var moveSpd = 4;

//        transform.position = transform.position + transform.up * moveSpd * Time.deltaTime;


//        transform.rotation = MyLib.GetAngleRotationFuncs(moveVecter[targetNo], transform, 5);
//        float len = Vector3.Distance(transform.position, moveVecter[targetNo]);
//        if (len < ENDMOVELEN)
//        {

//            targetNo++;
//            if (targetNo > moveVecter.Length - 1)
//            {
//                //ここに処理を追加できるようにしたい
//                //IsPoint = true;

//                isAttackEnd = true;
//                targetNo = 0;
//            }

//        }


//    }
//}
