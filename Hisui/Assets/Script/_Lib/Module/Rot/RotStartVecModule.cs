using UnityEngine;

public class RotStartVecModule : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Z軸を中心に0〜360度の間でランダムに回転させる (検索ワード)unity オブジェクトをランダムな方向へ向かせる z軸のみ
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));

        //return;
        //// ランダムな位置（ここでは原点中心の半径10m以内）を向く
        //Vector3 randomTarget = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        //transform.LookAt(randomTarget);

        //return;
        //// ランダムな方向ベクトル（X, Y, Zが-1〜1の範囲）を生成
        //Vector3 randomDirection = Random.onUnitSphere;
        //// その方向へ向くクォータニオン（回転）を作成して適用
        //transform.rotation = Quaternion.LookRotation(randomDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
