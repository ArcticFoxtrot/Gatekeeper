using System.Collections.Generic;


public class CauseOfDeathDocument : IDocument
{

    private string description;
    private List<CauseOfDeath> fulfillsCriteria;


    public CauseOfDeathDocument(string description, CauseOfDeath[] fulfillsCriteria)
    {
        this.description = description;
        this.fulfillsCriteria = new List<CauseOfDeath>(fulfillsCriteria);
    }

    public string ReadDocument()
    {
        return description;
    }

    public bool DoesFulfillCriteria(CauseOfDeath cause)
    {
        return fulfillsCriteria.Contains(cause);
    }
}
