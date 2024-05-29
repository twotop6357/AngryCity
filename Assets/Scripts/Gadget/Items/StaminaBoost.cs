using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBoost : Item
{
    public float duration;
    public float additionalStamina;
    public float additionalPassive;
    public Image image;
    private Coroutine staminaBoostCoroutine;

    private void Awake()
    {
        Initialize(duration);
    }

    private void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        Transform effect = canvas.transform.Find("Effect");
        Transform EffectTransform = effect.transform.Find("StaminaEffect");
        image = EffectTransform.GetComponent<Image>();
    }

    public override void UseItem()
    {
        base.UseItem();
        image.gameObject.SetActive(true);
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
        image.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}