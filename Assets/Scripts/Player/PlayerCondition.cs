using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    private float sec;
    private int min;


    Condition health { get { return uiCondition.health; } }
    Condition stamina {  get { return uiCondition.stamina; } }

    void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min += 1;
            sec = 0;
        }

        if (CharacterManager.Instance.Player.controller.isSprint == false)
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
        }
        else
        {
            stamina.Subtract(stamina.sprintValue * Time.deltaTime);
        }
        

        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        gameOverText.text = string.Format("{0}분 {1:D2}초간 노력했지만 끝내 차갑게 식었습니다...", min, (int)sec);
    }
}
