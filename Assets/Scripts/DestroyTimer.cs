using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    float timeToLive = 1f;
    float currentTime = 0f;
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
