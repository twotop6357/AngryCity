using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPaddle : MonoBehaviour
{
    public float paddlePower;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * paddlePower, ForceMode.Impulse);
        }
    }
}
