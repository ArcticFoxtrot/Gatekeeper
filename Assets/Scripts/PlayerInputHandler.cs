using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public void ApproveClicked()
    {
        Debug.Log("Approve clicked!");
        GameEventManager.Send(new GameEvent(this, GameEvent.EntryApproved));
    }

    public void DisapproveClicked()
    {   
        Debug.Log("Disapprove clicked!");
        GameEventManager.Send(new GameEvent(this, GameEvent.EntryNotApproved));
    }

    public void ReturnClicked()
    {
        Debug.Log("Return clicked!");
        GameEventManager.Send(new GameEvent(this, GameEvent.SentToEarth));
    }
}