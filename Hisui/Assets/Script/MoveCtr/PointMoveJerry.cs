using DG.Tweening;
using UniRx;
using UnityEngine;

public class PointMoveJerry : PointMove
{
    public override void MoveEnter()
    {
        //このクラスを継承してPointMoveJerryなどに移行？＊＊＊

        var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
        //トレイルサウンド用
        var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        seObj.GetComponent<AudioSource>().Play();

        //var pFloatMove = GetComponent<PointFloatMove>();
        isPointMoveEnd.Skip(1).Subscribe(pointBool =>
        {
            const float fadeSpeed = 1f;//1秒で止まる
            seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

            GetComponent<EnemyBase>().SetIsAttack();
            GetComponent<EnemyBase>().MoveEnd();
            GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        });

        //****
    }
}
