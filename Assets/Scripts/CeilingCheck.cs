using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CeilingCheck : MonoBehaviour
{
    public BoolEvent changeCeiling;

    private void Start()
    {
        changeCeiling.Invoke(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        changeCeiling.Invoke(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        changeCeiling.Invoke(false);
    }
}
