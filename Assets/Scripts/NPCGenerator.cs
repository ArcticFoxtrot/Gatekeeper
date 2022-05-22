using System;
using UnityEngine;
public class NPCGenerator : MonoBehaviour
{

    [SerializeField] private GameObject visualsPrefab;
    [Header("References to NPC visuals")]
    [SerializeField] private NPCHairCatalog hairs;
    [SerializeField] private NPCHeadCatalog heads;
    [SerializeField] private NPCEyeBrowCatalog eyeBrows;
    [SerializeField] private NPCEyeCatalog eyes;
    [SerializeField] private NPCNoseCatalog noses;
    [SerializeField] private NPCEarCatalog ears;
    [SerializeField] private NPCMouthCatalog mouths;
    [Header("References to NPC information")]
    [SerializeField] private NPCCauseOfDeathCatalog causeOfDeathCatalog;
    [SerializeField] private NPCBasicInformationSets NPCBasicInformationSets;
    [Header("NPC Skin color settings")]
    [SerializeField] private Color[] availableSkinColors;


    private GameObject currentNPC;

    private void OnEnable() {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable() {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    public GameObject GenerateNPC()
    {
        GameObject npcObject = GameObject.Instantiate(heads.GetRandom().HeadPrefab, this.transform.position, Quaternion.identity);

        if(npcObject.TryGetComponent(out NPC npc))
        {
            HeadController headController = npcObject.GetComponentInChildren<HeadController>();
            //set npc visuals
            Debug.Log("Found NPC Component");
            Sprite hair = hairs.GetRandom();
            Sprite eyeBrow = eyeBrows.GetRandom();
            Sprite eye = eyes.GetRandom();
            Sprite nose = noses.GetRandom();
            Sprite ear = ears.GetRandom();
            Sprite mouth = mouths.GetRandom();

            //set positions for sprites on head
            //hair
            headController.Hair.sprite = hair;
            //eyebrows
            headController.LeftEyeBrow.sprite = eyeBrow;
            headController.RightEyeBrow.sprite = eyeBrow;
            headController.LeftEyeBrow.flipX = true;

            //eyes
            headController.LeftEye.sprite = eye;
            headController.LeftEye.flipX = true;
            headController.RightEye.sprite = eye;
            
            //nose
            headController.Nose.sprite = nose;

            //ears
            headController.LeftEar.sprite = ear;
            headController.LeftEar.flipX = true;
            headController.RightEar.sprite = ear;
            
            //mouth
            headController.Mouth.sprite = mouth;

            //apply random skin color to head, ears and nose
            int colorIndex = UnityEngine.Random.Range(0, availableSkinColors.Length);
            ApplyColor(headController.GetComponent<SpriteRenderer>(), availableSkinColors[colorIndex]);
            ApplyColor(headController.LeftEar, availableSkinColors[colorIndex]);
            ApplyColor(headController.RightEar, availableSkinColors[colorIndex]);
            ApplyColor(headController.Nose, availableSkinColors[colorIndex]);
               
        }

        //setup NPC information
        SetupInformation(npcObject);
        GameEventManager.Send(new GameEvent(this, GameEvent.NPCCreated, new object[]{npcObject}));
        return npcObject;

    }

    private void SetupInformation(GameObject npcObject)
    {
        if(npcObject.TryGetComponent<NPC>(out NPC npc))
        {
            //get random stuff
            npc.CauseOfDeath = causeOfDeathCatalog.GetRandom().GetCauseOfDeathDocument();
            if(npc.CauseOfDeath == null)
            {
                Debug.LogError("cause of death is null");
            }
            npc.BasicInformation = NPCBasicInformationSets.GetRandomNPCInformation();
            if(npc.BasicInformation.Name == null)
            {
                Debug.LogError("basic info is null");
            }
        }
    }

    private void ApplyColor(SpriteRenderer renderer, Color color)
    {
        if(renderer != null)
        {
            renderer.color = color;
        }
        
    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {

    }
    
}

