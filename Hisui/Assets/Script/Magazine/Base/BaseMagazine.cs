using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;
using UnityEngine.Audio;
using static CreateBullet;
using static EnemyData;

public abstract class BaseMagazine : MonoBehaviour
{
    //全てがクラス名ではない　AddComponent際にパラメータ変更して扱う
    public enum MagazineType
    {
        TargetMagazine,
        FiveMagazine,
        CircleOneMagazine,

        CircleMagazineR,
        CircleMagazineL,

        TwoCarveMagazine,

        //NearMagazine,

        //NumAttackType,
    }

    public enum MagazineClassName
    {
        CircleMagazine,
    }

    public float shotTime = 0;

    public CreateBullet createBullet;

    public BulletTarget bulletTarget;

    [SerializeField]protected AudioSource arSe;
    public void SetLoadSe(AudioSource se)
    {
        arSe = se;
    }

    public virtual void Initialize() { }

    public abstract void MagazineEnter();

    public abstract void MagazineUpdate();

    public void TargetSet(ITarget it, BulletTarget bulletTarget, GameObject go)
    {
        if (it == null) return;

        switch (bulletTarget)
        {
            case BulletTarget.Player:
                it.Target = GameObject.FindGameObjectWithTag("Player").transform;
                break;
            case BulletTarget.LeftMiddle:
                //it.Target = leftMiddle;
                it.Target= GameObject.Find("LeftMiddle").transform;
                break;
            case BulletTarget.Up:
                it.Target = go.transform.Find("Up").gameObject.transform;
                break;
            case BulletTarget.Right:
                it.Target = go.transform.Find("Right").gameObject.transform;
                break;
            case BulletTarget.Left:
                it.Target = go.transform.Find("Left").gameObject.transform;
                break;
            case BulletTarget.Down:
                it.Target = go.transform.Find("Down").gameObject.transform;
                break;
            default:
                Debug.Log("TargetDEFAULT");
                break;
        }

    }
}
