using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceAnimationController : KetuEncounterController
{
    [SerializeField] PlayerController_Rick oldPlayer;
    [SerializeField] GameObject Blockers;
    [SerializeField] bool wipeOld;
    bool isFollowingKetu;

    LTDescr curTween;
    public override void NextDialogElement()
    {
        if (cinematicDialogElements[dialogCount].Goto != Vector2.zero) 
        {
            if (curTween != null) 
            {
                LeanTween.cancel(curTween.id);
            }
            curTween = LeanTween.move(cinematicDialogElements[dialogCount].toGo, new Vector3(cinematicDialogElements[dialogCount].Goto.x, cinematicDialogElements[dialogCount].Goto.y, 10f), cinematicDialogElements[dialogCount].duration);
        }
        if (cinematicDialogElements[dialogCount].followKetu && !isFollowingKetu) 
        {
            isFollowingKetu = true;
            CameraStateMachine.instance.SetFollowPoint(ketu.gameObject.transform.position);
        }
        if (!cinematicDialogElements[dialogCount].followKetu && isFollowingKetu)
        {
            isFollowingKetu = false;
            CameraStateMachine.instance.SetPlayerFollow(playerController.gameObject);
        }
        if (cinematicDialogElements[dialogCount].animateBrother) 
        {
            cinematicDialogElements[dialogCount].animateBrother.Animate();
        }
        base.NextDialogElement();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (oldPlayer && wipeOld) 
        {
            oldPlayer.DisableController();
            StartCoroutine(wipe());
        }
        base.OnTriggerEnter2D(collision);
    }
    IEnumerator wipe() 
    {
        yield return new WaitForSeconds(cinematicDialogElements[dialogCount].duration);
        playerController.gameObject.SetActive(true);
        Blockers.SetActive(true);
        Destroy(oldPlayer.gameObject);
    }
}
