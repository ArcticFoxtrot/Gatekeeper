using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject rulesPanel;

    public void OnShowRules()
    {
        rulesPanel.SetActive(true);
    }

    public void OnHideRules()
    {
        rulesPanel.SetActive(false);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
}

