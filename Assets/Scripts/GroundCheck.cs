using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{    
    public BoolEvent changeGrounded;
    private void Start()
    {
        changeGrounded.Invoke(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        changeGrounded.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        changeGrounded.Invoke(false);
    }

}
