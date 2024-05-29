using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float sec = 60;
    public int min = 0;
    public TextMeshProUGUI TimerText;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        sec -= Time.deltaTime;
        if(min >= 60f)
        {
            min += 1;
            sec -= 60f;
        }
        TimerText.text = string.Format("{0:D2} : {1:D2}", min, (int)sec);

        if(min == 0 && sec == 0f)
        {
            CharacterManager.Instance.Player.condition.uiCondition.health.Subtract(CharacterManager.Instance.Player.condition.uiCondition.health.curValue);
        }
    }
}
