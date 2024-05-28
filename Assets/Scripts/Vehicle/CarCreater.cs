using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CarCreater : MonoBehaviour
{
    [System.Serializable]
    private class ObjectInfo
    {
        public string objectName; // 오브젝트 이름
        public GameObject prefab; // 오브젝트 프리팹
    }
    [SerializeField] private ObjectInfo[] objectInfos = null;

    public Transform carSpawnPoint_vertical1;
    public Transform carSpawnPoint_vertical2; // rot y축기준 180
    public Transform carSpawnPoint_vertical3; // rot y축기준 -180
    public Transform carSpawnPoint_vertical4;
    public Transform carSpawnPoint_horizontal1; // rot y축기준 -90
    public Transform carSpawnPoint_horizontal2;
    public Transform carSpawnPoint_horizontal3;
    public Transform carSpawnPoint_horizontal4;
    List<Transform> spawnPointList = new List<Transform>();
    public float respawnTime = 1f;
    public float curTime;

    private void Awake()
    {
        spawnPointList.Add(carSpawnPoint_vertical1);
        spawnPointList.Add(carSpawnPoint_vertical2);
        spawnPointList.Add(carSpawnPoint_vertical3);
        spawnPointList.Add(carSpawnPoint_vertical4);
        spawnPointList.Add(carSpawnPoint_horizontal1);
        spawnPointList.Add(carSpawnPoint_horizontal2);
        spawnPointList.Add(carSpawnPoint_horizontal3);
        spawnPointList.Add(carSpawnPoint_horizontal4);
    }

    private void Update()
    {
        int randomPrefab = Random.Range(0, objectInfos.Length);
        int randomPosition = Random.Range(0, 8);
        curTime += Time.deltaTime;
        if(curTime > respawnTime)
        {
            curTime = 0f;
            //var carGo = ObjectPoolManager.instance.GetGo("Vehicle1");
            //carGo.transform.position = this.carSpawnPoint_vertical1.position;
            //carGo.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            var go = Instantiate(objectInfos[randomPrefab].prefab);
            go.transform.position = spawnPointList[randomPosition].position;
            go.transform.rotation = spawnPointList[randomPosition].rotation;
        }
    }
}