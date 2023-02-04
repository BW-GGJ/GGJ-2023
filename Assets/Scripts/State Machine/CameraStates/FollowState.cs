using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    private CameraStateMachine camControl;
    private Transform camera, player;
    public FollowState(CameraStateMachine cam) 
    {
        camControl = cam;
        camera = camControl.GetCamera().transform;
        player = camControl.GetPlayer().transform;
    }
    public override IEnumerator Update()
    {
        camera.position = Vector3.MoveTowards(new Vector3(camera.position.x, camera.position.y, 0), new Vector3(player.position.x, player.position.y, 0), camControl.GetSpeed() * Time.deltaTime);
        return base.Update();
    }
    public override IEnumerator GotoPoint()
    {
        camControl.SetState(new GotoState(camControl));
        return base.FollowPlayer();
    }
}
