using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartBoost : Item
{
    public float duration;
    public float additionalHealth;
    public Image image;
    private Coroutine heartBoostCoroutine;

    private void Awake()
    {
        Initialize(duration);
    }

    private void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        Transform effect = canvas.transform.Find("Effect");
        Transform EffectTransform = effect.transform.Find("HealthEffect");
        image = EffectTransform.GetComponent<Image>();
    }

    public override void UseItem()
    {
        base.UseItem();
        image.gameObject.SetActive(true);
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
        image.gameObject.SetActive(false) ;
        Destroy(gameObject);
    }
}