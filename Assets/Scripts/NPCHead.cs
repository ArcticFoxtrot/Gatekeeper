using UnityEngine;

[CreateAssetMenu(fileName = "NPCHead", menuName = "ScriptableObjects/NPCVisuals/NPCHead", order = 1)]
public class NPCHead : ScriptableObject
{
    public GameObject HeadPrefab;
    [Header("Hair")]
    public Transform HairPosition;
    [Header("Eyes")]
    public Transform LeftEyePosition;
    public Transform RightEyePosition;
    public Transform LeftEyeBrowPosition;
    public Transform RightEyeBrowPosition;
    [Header("Ears")]
    public Transform LeftEarPosition;
    public Transform RightEarPosition;
    [Header("Mouth")]
    public Transform MouthPosition;
    [Header("Nose")]
    public Transform NosePosition;
    
}