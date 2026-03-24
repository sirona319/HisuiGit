using UnityEngine;

public class TitleStart : MonoBehaviour
{

    [SerializeField] string BottuonNameOne;
    [SerializeField] string BottuonNameTwo;
    [SerializeField] string BottuonNameThree;

    bool isSelect = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        var time = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().fadeWaitTime -= Time.deltaTime;
        if (time > 0) return;

        const int LEFT = 0;
        if (!Input.GetMouseButtonDown(LEFT)) return;
        

        var selectObj = MyLib.DebugRayViewCameraPosZ();

        if(selectObj==null) return;

        //ボタンを押したとき遷移
        if (selectObj.gameObject.name == BottuonNameOne)
        {
            SelectStart();
        }

        else if (selectObj.gameObject.name == BottuonNameTwo)
        {
            SelectStart2();
        }

        else if (selectObj.gameObject.name == BottuonNameThree)
        {
            SelectStart3();
        }

    }

    //[SerializeField] FadeScene fadeScene;
    public void SelectStart()
    {
        if(isSelect) return;

        const float sceneChangeTime = 2f;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().
            SceneFade(BottuonNameOne.ToString(), 0f, sceneChangeTime);

        var se = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        var volume = .3f;
        MyLib.MyPlayOneSound("SE/決定ボタンを押す12", volume, se);

        isSelect = true;
    }

    public void SelectStart2()
    {
        if (isSelect) return;

        const float sceneChangeTime = 2f;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().
            SceneFade(BottuonNameTwo.ToString(), 0f, sceneChangeTime);

        var se = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        var volume = .3f;
        MyLib.MyPlayOneSound("SE/決定ボタンを押す12", volume, se);

        isSelect = true;
    }

    public void SelectStart3()
    {
        if (isSelect) return;

        const float sceneChangeTime = 2f;

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().
        SceneFade(BottuonNameThree.ToString(), 0f, sceneChangeTime);

        var se = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject;
        var volume = .3f;
        MyLib.MyPlayOneSound("SE/決定ボタンを押す12", volume, se);

        isSelect = true;
    }
}
