using System.Collections.Generic;
using UnityEngine;

public class TargetSet : Singleton<TargetSet>
{
    //Singleton<TargetSet>
    //private void Awake()//エラー
    //{
    //    DontDestroyOnLoad(this.gameObject);

    //}

    public enum Target
    {
        Local,
        Player,
        //LeftMiddle,
        //Up,
        //Right,
        //Left,
        //Down,

        //LocalDirection,
        //Abs,

        Relative,
        //斜め　四つ　
        //一番近いエネミーなど？　遠い敵　レーザー


    }

    //public enum TargetName
    //{
    //    Bullet,
    //    Circle,
    //    Point,
    //    Atk,
    //    //PointArray,
    //}


    //public void Init()
    //{
    //    //playerTarget = GameObject.FindWithTag("Player").transform;
    //}

    //バレット　サークル　単体
    //public Transform Set(TargetName name)
    //{
    //    var tArrayChild = transform.GetComponentsInChildren<TargetPoint>();

    //    Transform t = null;

    //    foreach (var tChild in tArrayChild)
    //    {
    //        if (tChild.GetComponent<TargetPoint>().tName == name)
    //            t = tChild.transform;

    //    }

    //    return TargetSelect(t.GetComponent<TargetPoint>().target, t);

    //}

    public Transform GetTargetTrans(Transform target,GameObject go)
    {

        //var tArrayChild = transform.GetComponentsInChildren<TargetPoint>();
        if (target.GetComponent<TargetPoint>().target == Target.Local)
        {
            return target;
            //Debug.Log("TargetPointが設定されていない");
        }
        return TargetSelect(target.GetComponent<TargetPoint>().target, target.position, go);

    }

    //public Vector3 GetTargetVec(Transform target)
    //{
    //    //var tArrayChild = transform.GetComponentsInChildren<TargetPoint>();
    //    if (target.GetComponent<TargetPoint>() == null)
    //    {
    //        Debug.Log("TargetPointが設定されていない");
    //    }
    //    return TargetSelect(target.GetComponent<TargetPoint>().target, target).position;

    //}

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
        //var tArrayChild = transform.GetComponentsInChildren<TargetPoint>();
        //List<Transform> tArrayPoints = new();

        //foreach (var tChild in tArrayChild)
        //{
        //    // 自分自身の場合は処理をスキップする
        //    if (tChild.gameObject == gameObject)
        //        continue;

        //    if (tChild.GetComponent<TargetPoint>().tName == TargetName.Point)
        //    {
        //        //lengthList.Add(tChild.GetComponent<TargetPoint>().pointLength);
        //        tArrayPoints.Add(tChild.transform);

        //    }

        //}

        //foreach (var tChild in tArrayPoints)
        //{
        //    var target = TargetSelect(tChild.GetComponent<TargetPoint>().target, tChild);
        //    pointList.Add(target);

        //}

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
                    break;
                }

                return p.transform;
            //break;
            //case Target.LeftMiddle: //固定
            //    //t = GameObject.Find(Target.LeftMiddle.ToString()).transform;
            //    break;
            //case Target.Up:
            //    //t = tChild;//transform.Find(tChild.name).gameObject.transform;
            //    t.position = transform.position + Vector3.up;
            //    break;
            //case Target.Down:
            //    //t = tChild;
            //    t.position = transform.position + Vector3.down;
            //    break;
            //case Target.Right:
            //    // t = tChild;
            //    t.position = transform.position + Vector3.right;
            //    break;
            //case Target.Left:
            //    //t = tChild;
            //    t.position = transform.position + Vector3.left;
            //    break;

            //case Target.LocalDirection://任意に設定した座標方向へ進み続ける
             //   return t;
            // t = tChild;
            // break;
            //case Target.Abs://固定 0座標を基準にした座標を設定 (画面が固定の時などに使用?)
            //    Debug.Log("Abs");
            //    var stayPos = transform.position;
            //    var go = (GameObject)Resources.Load("prefab/TargetVecObject");
            //    if (go == null) Debug.Log("Prefab ターゲット用オブジェクトが存在しない");
            //    transform.position = Vector3.zero;
            //    var obj = Instantiate(go, t.position, transform.rotation);

            //    obj.GetComponent<SetLinkObj>().linkObj = gameObject;
            //    t = obj.transform;
            //    //return obj.transform;
            //    transform.position = stayPos;

                //break;
            case Target.Relative://固定
                var goRelative = (GameObject)Resources.Load("prefab/TargetVecObject");
                if (goRelative == null) Debug.Log("Prefab ターゲット用オブジェクトが存在しない");
                var objRelative = Instantiate(goRelative, t, transform.rotation);
                objRelative.GetComponent<SetLinkObj>().linkObj = go;
                return objRelative.transform;
                //t = objRelative.transform;
               // break;
            //case BulletTarget.TargetVec://固定
            //    var child = transform.Find("TargetVec").transform;
            //    stayTarget = child;
            //    stayTarget.position = child.parent.TransformPoint(child.position);
            //    t = stayTarget.transform;

            //case BulletTarget.TargetVec://固定
            //    stayTarget = transform.Find("TargetVec").transform;
            //    t = stayTarget.transform;
            //break;
            default:
                return null;
                //Debug.Log("ターゲット未設定");
                //break;
        }

        return null;

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
