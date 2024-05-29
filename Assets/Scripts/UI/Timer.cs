using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float sec;
    public TextMeshProUGUI TimerText;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        sec -= Time.deltaTime;
        if(sec <= 0f)
        {
            sec = 0f;
        }
        if (sec == 0f)
        {
            CharacterManager.Instance.Player.condition.uiCondition.health.Subtract(CharacterManager.Instance.Player.condition.uiCondition.health.curValue);
        }
        TimerText.text = string.Format("{0:D2}ÃÊ ³²À½!", (int)sec+1);
    }

    public void AddTime(float time)
    {
        sec += time;
    }
}
