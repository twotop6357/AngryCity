using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreater : MonoBehaviour
{
    [SerializeField] private GameObject[] items = null;
    [SerializeField] private Transform[] spawnPoints = null;

    private void Start()
    {
        CreateItems();
    }
    private void CreateItems()
    {
        if(items == null || spawnPoints == null)
        {
            Debug.Log("배열에 오브젝트 할당 안됨");
        }
        else
        {
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                int itemPrefabIndex = Random.Range(0, items.Length);
                var go = Instantiate(items[itemPrefabIndex]);
                go.transform.position = spawnPoints[i].transform.position;
            }
        }
    }
}
