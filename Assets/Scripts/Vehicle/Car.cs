using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : PoolAble
{
    public float speed;
    public float rotationSpeed = 50f;
    public float detectionRange = 100f;
    private Transform playerTransform;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player Not Found");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if(distanceToPlayer <= detectionRange) 
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            directionToPlayer.y = 0;
            if(directionToPlayer == Vector3.zero)
            {
                Destroy(gameObject);
            }
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
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
