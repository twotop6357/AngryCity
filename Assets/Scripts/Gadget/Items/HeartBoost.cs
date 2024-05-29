using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartBoost : Item
{
    public float duration;
    public float additionalHealth;
    public Image heartEffect;
    private Coroutine heartBoostCoroutine;

    private void Awake()
    {
        Initialize(duration);
    }

    public override void UseItem()
    {
        base.UseItem();
        heartEffect.gameObject.SetActive(true);
        Transform child = transform.Find("Object");
        child.gameObject.SetActive(false);
        if(heartBoostCoroutine != null)
        {
            StopCoroutine(heartBoostCoroutine);
        }
        heartBoostCoroutine = StartCoroutine(HealthBoost());
    }

    private IEnumerator HealthBoost()
    {
        CharacterManager.Instance.Player.condition.uiCondition.health.maxValue += additionalHealth;
        CharacterManager.Instance.Player.condition.uiCondition.health.curValue = CharacterManager.Instance.Player.condition.uiCondition.health.maxValue;
        yield return new WaitForSeconds(durationTime);
        CharacterManager.Instance.Player.condition.uiCondition.health.maxValue -= additionalHealth;
        CharacterManager.Instance.Player.condition.uiCondition.health.curValue = CharacterManager.Instance.Player.condition.uiCondition.health.maxValue;
        heartBoostCoroutine = null;
        heartEffect.gameObject.SetActive(false) ;
        Destroy(gameObject);
    }
}