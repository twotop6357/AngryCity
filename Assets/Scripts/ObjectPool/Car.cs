using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : PoolAble
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            CharacterManager.Instance.Player.condition.uiCondition.health.curValue -= 100;
        }
    }
}
