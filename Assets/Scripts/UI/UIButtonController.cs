using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonController : MonoBehaviour
{
    public GameObject finishPanel;
    public void ReturnButton()
    {
        finishPanel.SetActive(false);
        //SceneManager.LoadScene()
        Debug.Log("돌아가기");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
        finishPanel.SetActive(false );
    }
}
