using UnityEngine;
using UnityEngine.Playables;

public class NarrationAsset : PlayableAsset
{
    // [SerializeField]
    // ExposedReference<GameObject> narrationGameObject;

    //[SerializeField]
    //ExposedReference<TMP_Text> text;
    [TextArea(1, 20)]
    public string TextErea;
    public bool isTextPause=true;
    public NarrationBehaviour narration = new NarrationBehaviour();

    //public TMP_Text mText;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<NarrationBehaviour>.Create(graph, narration);

        //var behaviour = playable.GetBehaviour();

        playable.GetBehaviour().inputText = TextErea;
        playable.GetBehaviour().isTextPause = isTextPause;
        // behaviour.narrationGameObject = narrationGameObject.Resolve(graph.GetResolver());

        //behaviour.mTextUI = owner.GetComponent<TMP_Text>();


        //behaviour.mTextUI= (TMP_Text)narrationGameObject.defaultValue;
        //behaviour.OnPlayableCreate(playable);


        return playable;
        //throw new System.NotImplementedException();
    }
}
