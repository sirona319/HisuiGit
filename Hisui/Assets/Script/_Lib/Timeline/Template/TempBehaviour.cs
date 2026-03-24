using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TempBehaviour : PlayableBehaviour
{
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        //Debug.Log("OnGraphStartTEMP");
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
      //  Debug.Log("OnGraphStopTEMP");
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
       // Debug.Log("OnBehaviourPause TEMP");
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }
}
