using System.Collections.Generic;


public class CauseOfDeathDocument : IDocument// read scriptable object
{

    private string description;
    private List<Criteria> fulfillsCriteria;


    public CauseOfDeathDocument(string description, Criteria[] fulfillsCriteria)
    {
        this.description = description;
        this.fulfillsCriteria = new List<Criteria>(fulfillsCriteria);
    }


    public string ReadDocument()
    {
        return description;
    }

    public bool DoesFulfillCriteria(Criteria criteria)
    {
        return fulfillsCriteria.Contains(criteria);
    }
}
