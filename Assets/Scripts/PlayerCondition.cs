using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina {  get { return uiCondition.stamina; } }

    void Update()
    {
        if (CharacterManager.Instance.Player.controller.isSprint == false)
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
        }
        else
        {
            stamina.Subtract(stamina.passiveValue * Time.deltaTime);
        }
        

        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("ав╬З╢ы!");
    }
}
