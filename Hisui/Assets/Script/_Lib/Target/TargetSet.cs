using System.Collections.Generic;
using UnityEngine;

public class TargetSet : Singleton<TargetSet>
{

    public enum Target
    {
        Local,
        Player,
        Relative,
        //斜め　四つ　
        //一番近いエネミーなど？　遠い敵　レーザー
    }

    [SerializeField] GameObject TargetVecObject;

    public Transform GetTargetTrans(Transform target,GameObject go)
    {

        if (target.GetComponent<TargetPoint>().target == Target.Local)
        {
            return target;

        }
        return TargetSelect(target.GetComponent<TargetPoint>().target, target.position, go);

    }

    public List<Transform> SetPointArray(List<Transform> pointList, GameObject go)
    {
        //生成位置から見た固定座標を使用するときに使う

        List<Transform> tArrayPoints = new();
        foreach (var tChild in pointList)
        {
            var tPoint = tChild.GetComponent<TargetPoint>();
            if (tPoint.target == Target.Local)
            {
                return pointList;
                //Debug.Log("TargetPointが設定されていない");
            }

            var t = TargetSelect(tPoint.target, tChild.position, go);
            tArrayPoints.Add(t);

        }

        return tArrayPoints;

    }

    Transform TargetSelect(Target type,Vector3 t, GameObject go)
    {
        //一番近いエネミーなど？　遠い敵　レーザー武器用など（Player）
        //Instanteiateで生成することで子階層から外す　座標ずれを防ぐため
        switch (type)
        {
            case Target.Player:
                var p = GameObject.FindWithTag(Target.Player.ToString());
                if (p == null)
                {
                    Debug.Log("プレイヤーが存在しない");
                    return null;
                }

                return p.transform;

            case Target.Relative://固定
                //var goRelative = (GameObject)Resources.Load(TargetVecObject.name);
                //if (goRelative == null) Debug.Log("Prefab ターゲット用オブジェクトが存在しない");
                var objRelative = Instantiate(TargetVecObject, t, transform.rotation);
                objRelative.GetComponent<SetLinkObj>().linkObj = go;
                return objRelative.transform;

            default:
                return null;

        }

    }


    //public List<Vector3> SetArrayVec()
    //{
    //    var stayPos = transform.position;
    //    //Transform[] tArray=null;
    //    Transform[] tArrayChild = transform.GetComponentsInChildren<Transform>();
    //    List<Transform> tArrayPoints = new();

    //    foreach (Transform tChild in tArrayChild)
    //    {
    //        // 自分自身の場合は処理をスキップする
    //        if (tChild.gameObject == gameObject)
    //            continue;

    //        if (tChild.name.Contains("Point"))
    //            tArrayPoints.Add(tChild);
    //    }

    //    if (tArrayPoints.Count<=0)
    //    {
    //        throw new System.Exception("Pointが子階層に存在していない");
    //        //Debug.Log("生成する敵の移動基点座標が全て指定されていない");
    //    }

    //    List<Vector3> tArrayPointsReturn = new();
    //    foreach (var tChild in tArrayPoints)
    //    {
    //        //if (t == null) return null;
    //        //Transform t = null;
    //        Vector3 pos=Vector3.zero;
    //        if (tChild.name.Contains(Target.Player.ToString()))
    //            pos = GameObject.FindWithTag(Target.Player.ToString()).transform.position;

    //        else if (tChild.name.Contains(Target.LeftMiddle.ToString()))
    //            pos = GameObject.Find(Target.LeftMiddle.ToString()).transform.position;

    //        else if (tChild.name.Contains(Target.Vec.ToString()))
    //        {
    //            var go = (GameObject)Resources.Load("prefab/Bullet/TargetVecObject");
    //            transform.position = Vector3.zero;

    //            var obj = Instantiate(go, tChild.position, transform.rotation);

    //            obj.GetComponent<SetLinkObj>().linkObj = gameObject;
    //            pos = obj.transform.position;
    //        }
    //        else if (tChild.name.Contains(Target.LocalTarget.ToString()))//LocalTargetにする？敵と一緒に移動する座標？Vector3を返すときは関係なく固定？
    //        {
    //            //tChild.parent = GameObject.Find("Center").transform;
    //            transform.position = Vector3.zero;
    //            pos = tChild.position;
    //        }

    //        tArrayPointsReturn.Add(pos);

    //    }
    //    transform.position = stayPos;
    //    return tArrayPointsReturn;

    //}
}
