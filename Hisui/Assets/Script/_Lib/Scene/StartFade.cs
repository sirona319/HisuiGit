using UnityEngine;

public class StartFade : MonoBehaviour
{

    //[SerializeField] Fade fade;
    void Start()
    {
        var fade = GameObject.FindGameObjectWithTag("Fade");
        if (fade == null) return;


        //プレイヤー座標を受け取る？
        fade.GetComponent<FadeScene>().FadeOut(1f);

        //タイムラインの最後？　シグナル？
        //GameMgr.I.FadeOut();

        //var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
        //fade.FadeOut(1f);

        //すでにSceneに配置している敵の数を追加
        //enemyAllCount += MyLib.EnemyNum();

        //SoundManager.I.BgmChange(SoundManager.BGMType.game);

        //カーソルをオフにする
        //CursolManager.I.SetCursol(false);

        //Cursor.visible = false;

    }

}
