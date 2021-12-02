using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCheck : MonoBehaviour
{
    private bool isTouchingCeiling = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingCeiling = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingCeiling = false;
    }

    public bool GetIsTouchingCeiling()
    {
        return isTouchingCeiling;
    }
}
