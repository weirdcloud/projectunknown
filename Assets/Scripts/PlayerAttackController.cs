using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float cooldown = 0.5f;

    float timeSinceShot = 0f;

    void Update()
    {
        timeSinceShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && (timeSinceShot >= cooldown))
        {
            Shoot();
            timeSinceShot = 0f;
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = mousePos - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        GameObject projInstance = Instantiate<GameObject>(projectile, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        projInstance.GetComponent<Rigidbody2D>().AddForce(((Vector2)aimDirection).normalized * 10, ForceMode2D.Impulse);
    }
}
