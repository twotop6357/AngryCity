using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroButtonController : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject startPanel;

    public void HelpButton()
    {
        helpPanel.SetActive(true);
    }

    public void HelpPanelCloseButton()
    {
        helpPanel.SetActive(false);
    }

    public void StartButton()
    {
        startPanel.SetActive(true);
    }

    public void GoToGame()
    {
        startPanel.SetActive(false );
        SceneManager.LoadScene("SampleScene");
    }
}
