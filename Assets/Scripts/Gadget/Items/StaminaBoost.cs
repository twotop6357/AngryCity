using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBoost : Item
{
    public float duration;
    public float additionalStamina;
    public float additionalPassive;
    public Image staminaBoostEffect;
    private Coroutine staminaBoostCoroutine;

    private void Awake()
    {
        Initialize(duration);
    }

    public override void UseItem()
    {
        base.UseItem();
        staminaBoostEffect.gameObject.SetActive(true);
        Transform child = transform.Find("Penta");
        child.gameObject.SetActive(false);
        if(staminaBoostCoroutine != null)
        {
            StopCoroutine(staminaBoostCoroutine);
        }
        staminaBoostCoroutine = StartCoroutine(StaminaBurst());
    }

    private IEnumerator StaminaBurst()
    {
        CharacterManager.Instance.Player.condition.uiCondition.stamina.maxValue += additionalStamina;
        CharacterManager.Instance.Player.condition.uiCondition.stamina.passiveValue += additionalPassive;
        yield return new WaitForSeconds(durationTime);
        CharacterManager.Instance.Player.condition.uiCondition.stamina.maxValue -= additionalStamina;
        CharacterManager.Instance.Player.condition.uiCondition.stamina.passiveValue -= additionalPassive;
        staminaBoostCoroutine = null;
        staminaBoostEffect.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}