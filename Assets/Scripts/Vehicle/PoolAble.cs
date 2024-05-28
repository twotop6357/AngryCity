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
        Pool.Release(gameObject);
    }
}