using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;
using UnityEngine.Audio;
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

    protected AudioResource arSe;
    public void SetLoadSe(AudioResource se)
    {
        arSe = se;
    }

    public abstract void Initialize();

    public abstract void MagazineEnter();

    public abstract void MagazineUpdate();


}
