using UnityEngine;
public class NPCGenerator : MonoBehaviour
{

    [SerializeField] private GameObject NPCPrefab;
    [SerializeField] private GameObject visualsPrefab;
    [Header("References to NPC visuals/catalogues")]
    [SerializeField] private NPCHairCatalog hairs;
    [SerializeField] private NPCHeadCatalog heads;
    [SerializeField] private NPCEyeBrowCatalog eyeBrows;
    [SerializeField] private NPCEyeCatalog eyes;
    [SerializeField] private NPCNoseCatalog noses;
    [SerializeField] private NPCEarCatalog ears;
    [SerializeField] private NPCMouthCatalog mouths;


    public GameObject GenerateNPC()
    {
        GameObject npcObject = GameObject.Instantiate(NPCPrefab, transform.position, Quaternion.identity);
        if(npcObject.TryGetComponent(out NPC npc))
        {
            //set npc visuals
            NPCHead head = heads.GetRandom();
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
                leftEyeBrowRenderer.flipY = true;
            }
            GameObject rightEyeBrow = GameObject.Instantiate(visualsPrefab, head.LeftEyeBrowPosition.position, Quaternion.identity, npcObject.transform);
            if(rightEyeBrow.TryGetComponent<SpriteRenderer>(out SpriteRenderer rightEyeBrowRenderer))
            {
                rightEyeBrowRenderer.sprite = eyeBrow;
            }
            //eyes
            GameObject leftEye = GameObject.Instantiate(visualsPrefab, head.LeftEyePosition.position, Quaternion.identity, npcObject.transform);
            if(leftEye.TryGetComponent<SpriteRenderer>(out SpriteRenderer leftEyeRenderer))
            {
                leftEyeRenderer.sprite = eye;
                leftEyeRenderer.flipY = true;
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
                leftEarRenderer.flipY = true;
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

        }
        return npcObject;

    }

}



