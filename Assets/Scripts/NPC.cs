using System;
using UnityEngine;

public class NPC : MonoBehaviour 
{

    public NPCBasicInformation BasicInformation;
    public CauseOfDeathDocument CauseOfDeath;

    [SerializeField] Animator animator;

    public void MoveToWindow()
    {
        Debug.Log("Moving to window!");
        animator.SetTrigger("MoveToWindow");
    }

    public void WindowReached()
    {
        GameEventManager.Send(new GameEvent(this, GameEvent.NextNPCReady, new object[]{this.gameObject}));
    }

    public void AnimationEnded()
    {
        GameEventManager.Send(new GameEvent(this, GameEvent.NPCReachedDestination));
    }

    public void MoveToHeaven()
    {
        animator.SetTrigger("MoveToHeaven");
    }


    public void MoveToHell()
    {
        animator.SetTrigger("MoveToHell");
    }
}

