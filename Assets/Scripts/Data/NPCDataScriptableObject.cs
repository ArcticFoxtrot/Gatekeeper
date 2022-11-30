using UnityEngine;
using System.Linq;
using System;
using Zenject;
using System.Collections.Generic;

namespace Gatekeeper.Data
{
    public interface INPCDataProvider
    {
        public NPCBasicInformation GetRandomNPCInformation();
        public CauseOfDeathDocument GetRandomCauseOfDeath();
        public RitualDocument GetRandomRitual();
    }

    public class NPCDataProvider : INPCDataProvider
    {
        [Inject]
        CauseOfDeathDocument[] CausesOfDeath;
        [Inject]
        NPCBasicInformationData BasicInformations;
        [Inject]
        RitualDocument[] RitualDocuments;
        public CauseOfDeathDocument GetRandomCauseOfDeath()
        {
            int randomInt = UnityEngine.Random.Range(0, CausesOfDeath.Length - 1);
            return CausesOfDeath[randomInt];
        }

        public NPCBasicInformation GetRandomNPCInformation()
        {
            //we could construct this info instance in the class calling this instead, if we want to separate data from the use of the data
            NPCBasicInformation info = new NPCBasicInformation();
            int nameIndex = UnityEngine.Random.Range(0, BasicInformations.Names.Length);
            info.Name = BasicInformations.Names[nameIndex];
            int originIndex = UnityEngine.Random.Range(0, BasicInformations.Origins.Length);
            info.Origin = BasicInformations.Origins[originIndex];

            info.Age = UnityEngine.Random.Range(BasicInformations.MinAge, BasicInformations.MaxAge);
            info.BirthYear = DateTime.Now.Year - info.Age;
            info.DeathYear = DateTime.Now.Year;

            return info;
        }

        public RitualDocument GetRandomRitual()
        {
            int randomInt = UnityEngine.Random.Range(0, RitualDocuments.Length);
            return RitualDocuments[randomInt];
        }
    }

    [Serializable]
    public class NPCBasicInformationData
    {
        public Name[] Names;
        public Origin[] Origins;
        public int MinAge;
        public int MaxAge;

    }

    [Serializable]
    public class CauseOfDeathDocument : IDocument
    {
        public string Description;
        public CauseOfDeath[] FulfilledCriteria;
        public string ReadDocument()
        {
            return Description;
        }

        public bool DoesFulfillCriteria(CauseOfDeath cause)
        {
            return FulfilledCriteria.Contains(cause);
        }
    }
    
    [Serializable]
    public class RitualDocument : IDocument
    {

        public string Description;
        public Ritual[] FulfilledCriteria;

        public string ReadDocument()
        {
            return Description;
        }

        public bool DoesFulfillCriteria(Ritual ritual)
        {
            return FulfilledCriteria.Contains(ritual);
        }
    }

    public class NPCBasicInformation : IDocument
    {
        public int BirthYear;
        public int DeathYear;
        public int Age;
        public Name Name;
        public Origin Origin;

        public string ReadDocument()
        {
            return String.Format("Name: {0} \nAge : {1} \nBirth: {2} \nFrom: {3}", Name, Age, BirthYear, Origin.ToString());
        }
    }


    [CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCDataScriptableObject", order = 1)]
    public class NPCDataScriptableObject : ScriptableObjectInstaller<NPCDataScriptableObject>
    {
        public CauseOfDeathDocument[] CausesOfDeath;
        public NPCBasicInformationData BasicInformations;
        public RitualDocument[] Rituals;

        public override void InstallBindings()
        {
            Container.BindInstance(CausesOfDeath);
            Container.BindInstance(BasicInformations);
            Container.BindInstance(Rituals);

        }
    }
}