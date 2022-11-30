using System;
using UnityEngine;
using Zenject;
using Gatekeeper.Data;

public class NPCGenerator : MonoBehaviour
{

    [SerializeField] private GameObject visualsPrefab;


    [Inject]
    private INPCVisualDataProvider npcVisualDataProvider;

    [Inject]
    private INPCDataProvider npcDataProvider;

    [Header("NPC Skin color settings")]
    [SerializeField] private Color[] availableSkinColors;


    private GameObject currentNPC;

    private int generatedNPCs = 0;
    private int maximumNPCsForCurrentRound = 1;

    private void OnEnable()
    {
        GameEventManager.OnGameEvent += HandleGameEvent;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameEvent -= HandleGameEvent;
    }

    public GameObject GenerateNPC()
    {
        if (generatedNPCs < maximumNPCsForCurrentRound)
        {
            GameObject npcObject = GameObject.Instantiate(npcVisualDataProvider.GetRandomHead(), this.transform.position, Quaternion.identity);

            if (npcObject.TryGetComponent(out NPC npc))
            {
                HeadController headController = npcObject.GetComponentInChildren<HeadController>();
                //set npc visuals
                Sprite hair = npcVisualDataProvider.GetRandomHair();
                Sprite eyeBrow = npcVisualDataProvider.GetRandomEyebrow();
                Sprite eye = npcVisualDataProvider.GetRandomEyes();
                Sprite nose = npcVisualDataProvider.GetRandomNose();
                Sprite ear = npcVisualDataProvider.GetRandomEar();
                Sprite mouth = npcVisualDataProvider.GetRandomMouth();

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
            GameEventManager.Send(new GameEvent(this, GameEvent.NPCCreated, new object[] { npcObject }));
            generatedNPCs++;
            return npcObject;
        }
        else
        {
            return null;
        }

    }

    public void ResetRoundWithMaximum(int maxNumber)
    {
        generatedNPCs = 0;
        maximumNPCsForCurrentRound = maxNumber;
    }

    private void SetupInformation(GameObject npcObject)
    {
        if (npcObject.TryGetComponent<NPC>(out NPC npc))
        {
            //get random stuff
            npc.CauseOfDeath = npcDataProvider.GetRandomCauseOfDeath();
            if (npc.CauseOfDeath == null)
            {
                Debug.LogError("cause of death is null");
            }
            npc.BasicInformation = npcDataProvider.GetRandomNPCInformation();
            if (String.IsNullOrEmpty(npc.BasicInformation.Name.ToString()))
            {
                Debug.LogError("basic info is null");
            }
            npc.Ritual = npcDataProvider.GetRandomRitual();
            if (npc.Ritual == null)
            {
                Debug.LogError("ritual document is null");
            }
        }
    }

    private void ApplyColor(SpriteRenderer renderer, Color color)
    {
        if (renderer != null)
        {
            renderer.color = color;
        }

    }

    private void HandleGameEvent(object sender, GameEvent gameEvent)
    {

    }

}

