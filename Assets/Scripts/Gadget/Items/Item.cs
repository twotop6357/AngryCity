using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float durationTime;

    public void Initialize(float duration)
    {
        durationTime = duration;
    }

    public virtual void UseItem()
    {

    }
}