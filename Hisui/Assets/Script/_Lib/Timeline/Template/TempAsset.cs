using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TempAsset : PlayableAsset
{

    public TempBehaviour temp = new TempBehaviour();


    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TempBehaviour>.Create(graph, temp);



        return playable;

    }


}
