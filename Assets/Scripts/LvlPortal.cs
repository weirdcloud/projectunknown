using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LvlPortal : MonoBehaviour
{
    public UnityEvent PortalEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealthController>() != null)
        {
            PortalEnter.Invoke();
        }
    }
}
