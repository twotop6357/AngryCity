using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedStar : Item
{
    public float duration;
    public float additionalSpeed;
    public Image sprintEffect;
    private Coroutine speedStarCoroutine;

    private void Awake()
    {
        Initialize(duration);
    }

    public override void UseItem()
    {
        base.UseItem();
        sprintEffect.gameObject.SetActive(true);
        Transform child = transform.Find("5 Side Diamond");
        child.gameObject.SetActive(false);
        if(speedStarCoroutine != null )
        {
            StopCoroutine( speedStarCoroutine );
        }
        speedStarCoroutine = StartCoroutine(SpeedBoost());
    }

    private IEnumerator SpeedBoost()
    {
        CharacterManager.Instance.Player.controller.moveSpeed += additionalSpeed;
        yield return new WaitForSeconds( durationTime );
        CharacterManager.Instance.Player.controller.moveSpeed -= additionalSpeed;
        speedStarCoroutine = null;
        sprintEffect.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
