using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoState : State
{
    private CameraStateMachine camControl;
    private Transform camera;

    public GotoState(CameraStateMachine cam) 
    {
        camControl = cam;
        camera = camControl.GetCamera().transform;
    }

    public override IEnumerator Update()
    {
        camera.position = Vector3.MoveTowards(new Vector3(camera.position.x, camera.position.y, 0), camControl.GetPoint(), camControl.GetSpeed() * Time.deltaTime);
        return base.Update();
    }

    public override IEnumerator FollowPlayer()
    {
        camControl.SetState(new FollowState(camControl));
        return base.FollowPlayer();
    }
}
