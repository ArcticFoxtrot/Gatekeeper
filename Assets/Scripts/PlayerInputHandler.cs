using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public void ApproveClicked()
    {
        
        GameEventManager.Send(new GameEvent(this, GameEvent.EntryApproved));
    }

    public void DisapproveClicked()
    {   
       
        GameEventManager.Send(new GameEvent(this, GameEvent.EntryNotApproved));
    }

    public void ReturnClicked()
    {
        
        GameEventManager.Send(new GameEvent(this, GameEvent.SentToEarth));
    }
}