using UnityEngine;
using UnityEngine.InputSystem;


//boxColider Rigidbody EventTrigger
//複数コンポーネント追加が必要なため使わない


public class SceneChangeUi : MonoBehaviour
{

    public void SceneChangeTrigger(GameObject go)
    {
        const float sceneChangeTime = 2f;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().
            SceneFade(go.name, 0f, sceneChangeTime);

        var se = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        var volume = .3f;
        MyLib.MyPlayOneSound("SE/決定ボタンを押す12", volume, se);
    }

}
