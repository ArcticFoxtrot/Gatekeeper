using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GodGenerator godGenerator;

    private void Start()
    {
        godGenerator?.Initialize();
    }
}
