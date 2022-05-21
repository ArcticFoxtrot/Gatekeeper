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

    public GameObject GenerateNPC(Transform startPosition)
    {
        HeadController head = heads.GetRandom().HeadPrefab.GetComponent<HeadController>();
        GameObject npcObject = GameObject.Instantiate(head.gameObject, startPosition.position, Quaternion.identity);

        if(npcObject.TryGetComponent(out NPC npc))
        {
            //set npc visuals
            
            Sprite hair = hairs.GetRandom();
            Sprite eyeBrow = eyeBrows.GetRandom();
            Sprite eye = eyes.GetRandom();
            Sprite nose = noses.GetRandom();
            Sprite ear = ears.GetRandom();
            Sprite mouth = mouths.GetRandom();

            //set positions for sprites on head
            //hair
            GameObject hairObject = GameObject.Instantiate(visualsPrefab, head.HairPosition.position, Quaternion.identity, npcObject.transform);
            if(hairObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer hairRenderer))
            {
                hairRenderer.sprite = hair;
            }
            //eyebrows
            GameObject leftEyeBrow = GameObject.Instantiate(visualsPrefab, head.LeftEyeBrowPosition.position, Quaternion.identity, npcObject.transform);
            if(leftEyeBrow.TryGetComponent<SpriteRenderer>(out SpriteRenderer leftEyeBrowRenderer))
            {
                leftEyeBrowRenderer.sprite = eyeBrow;
                leftEyeBrowRenderer.flipX = true;
            }
            GameObject rightEyeBrow = GameObject.Instantiate(visualsPrefab, head.RightEyeBrowPosition.position, Quaternion.identity, npcObject.transform);
            if(rightEyeBrow.TryGetComponent<SpriteRenderer>(out SpriteRenderer rightEyeBrowRenderer))
            {
                rightEyeBrowRenderer.sprite = eyeBrow;
            }
            //eyes
            GameObject leftEye = GameObject.Instantiate(visualsPrefab, head.LeftEyePosition.position, Quaternion.identity, npcObject.transform);
            if(leftEye.TryGetComponent<SpriteRenderer>(out SpriteRenderer leftEyeRenderer))
            {
                leftEyeRenderer.sprite = eye;
                leftEyeRenderer.flipX = true;
            }
            GameObject rightEye = GameObject.Instantiate(visualsPrefab, head.RightEyePosition.position, Quaternion.identity, npcObject.transform);
            if(rightEye.TryGetComponent<SpriteRenderer>(out SpriteRenderer rightEyeRenderer))
            {
                rightEyeRenderer.sprite = eye;
            }
            //nose
            GameObject noseObject = GameObject.Instantiate(visualsPrefab, head.NosePosition.position, Quaternion.identity, npcObject.transform);
            if(noseObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer noseRenderer))
            {
                noseRenderer.sprite = nose;
            }
            //ears
            GameObject leftEar = GameObject.Instantiate(visualsPrefab, head.LeftEarPosition.position, Quaternion.identity, npcObject.transform);
            if(leftEar.TryGetComponent<SpriteRenderer>(out SpriteRenderer leftEarRenderer))
            {
                leftEarRenderer.sprite = ear;
                leftEarRenderer.flipX = true;
            }
            GameObject rightEar = GameObject.Instantiate(visualsPrefab, head.RightEarPosition.position, Quaternion.identity, npcObject.transform);
            if(rightEar.TryGetComponent<SpriteRenderer>(out SpriteRenderer rightEarRenderer))
            {
                rightEarRenderer.sprite = ear;
            }
            //mouth
            GameObject mouthObject = GameObject.Instantiate(visualsPrefab, head.MouthPosition.position, Quaternion.identity, npcObject.transform);
            if(mouthObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer mouthRenderer))
            {
                mouthRenderer.sprite = mouth;
            }
            //background
            SpriteRenderer headRenderer = null;
            if(npcObject.GetComponent<SpriteRenderer>() != null)
            {
                headRenderer = npcObject.GetComponent<SpriteRenderer>();
                headRenderer.sprite = head.Head;
            }

            //apply random skin color to head, ears and nose
            int colorIndex = UnityEngine.Random.Range(0, availableSkinColors.Length);
            ApplyColor(headRenderer, availableSkinColors[colorIndex]);
            ApplyColor(leftEarRenderer, availableSkinColors[colorIndex]);
            ApplyColor(rightEarRenderer, availableSkinColors[colorIndex]);
            ApplyColor(noseRenderer, availableSkinColors[colorIndex]);
               
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

