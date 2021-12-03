using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeAttackController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float cooldown = 0.5f;

    float timeSinceShot = 0f;
    GameObject target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealthController>().gameObject;
    }

    void Update()
    {
        timeSinceShot += Time.deltaTime;

        if ((timeSinceShot >= cooldown) && (target != null))
        {
            Shoot();
            timeSinceShot = 0f;
        }
    }

    private void Shoot()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 aimDirection = targetPos - transform.position;
        GameObject projInstance = Instantiate<GameObject>(projectile, transform.position, Quaternion.identity);
        projInstance.GetComponent<Rigidbody2D>().AddForce(((Vector2)aimDirection).normalized * 10, ForceMode2D.Impulse);
    }
}
