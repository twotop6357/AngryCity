using UnityEngine;
using UnityEngine.Pool;

public class PoolAble : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    private void Start()
    {
        Pool = this.GetComponent<IObjectPool<GameObject>>();
    }
    public void ReleaseObject()
    {
        Debug.Log(ObjectPoolManager.instance.GetGo(transform.name));
        Pool.Release(gameObject);
    }
}