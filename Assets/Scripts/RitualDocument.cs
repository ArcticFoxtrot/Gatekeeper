using System.Collections.Generic;


public class RitualDocument : IDocument
{

    private string description;
    private List<Ritual> fulfillsCriteria;


    public RitualDocument(string description, Ritual[] fulfillsCriteria)
    {
        this.description = description;
        this.fulfillsCriteria = new List<Ritual>(fulfillsCriteria);
    }

    public string ReadDocument()
    {
        return description;
    }

    public bool DoesFulfillCriteria(Ritual ritual)
    {
        return fulfillsCriteria.Contains(ritual);
    }
}