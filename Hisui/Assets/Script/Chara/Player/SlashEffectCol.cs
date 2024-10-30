using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffectCol : MonoBehaviour
{
    //private bool isPlayerAttackHit = false;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("EffectTrigger");
        //if (IsBreak) return;

        //プレイヤーが死んでたら無効
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<HPUIControl>().GetHp() <= 0)
            return;

        //攻撃インターバル
        //if (isPlayerAttackHit) return;
        if (other.gameObject.transform.CompareTag("Enemy"))
        {

            //other.GetComponent<EnemyBase>().EnemyDamageEffect(30);
            GetComponent<BoxCollider>().enabled = false;
            // isPlayerAttackHit = true;

            //const float PATKINTERVAL = 0.1f;
            //StartCoroutine(MyLib.DelayCoroutine(PATKINTERVAL, () =>
            //{ isPlayerAttackHit = false; }));
        }

        if (other.gameObject.transform.CompareTag("Counter"))
        {
            Debug.Log("跳ね返したPlayer");
            const float volume = 0.15f;
            var audioStartSource = this.GetComponent<AudioSource>();
            var sound = (AudioClip)Resources.Load("SE/" + "剣で打ち合う2");
            audioStartSource.PlayOneShot(sound, volume);


            //var sparkComp = other.GetComponent<WizardSpark>();
            //sparkComp.counterCount--;
            //sparkComp.tag = "CounterEnemy";
            //sparkComp.target = sparkComp.startTrans;
            //sparkComp.isEnemyCounter = true;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
