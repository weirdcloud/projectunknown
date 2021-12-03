using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDoubleJump : MonoBehaviour
{
    [SerializeField]
    GameObject effect;

    public void OnDoubleJump()
    {
        Instantiate<GameObject>(effect, transform.position, Quaternion.identity);
    }
}
