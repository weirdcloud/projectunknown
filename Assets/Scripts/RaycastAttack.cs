using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttack : MonoBehaviour
{
    [SerializeField]
    LineRenderer line;

    Vector2 point0 = Vector2.zero;
    Vector2 point1;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
        if (line.enabled)
            DrawLine();
    }

    void Shoot()
    {
        int hittables = LayerMask.GetMask("Ground", "Enemy");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = mousePos - transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, aimDirection, Mathf.Infinity, hittables);

        if (hitInfo)
        {
            print(hitInfo.collider);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red, 3f);

            point1 = hitInfo.point - (Vector2)transform.position;

            IHealthController healthController = hitInfo.collider.gameObject.GetComponent<IHealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(12);
            }
        } 
        else
        {
            point1 = (Vector2)aimDirection;
        }

        line.enabled = true;
        StartCoroutine(HideLine());
    }

    void DrawLine()
    {
        line.SetPosition(0, point0);
        line.SetPosition(1, point1);
    }

    IEnumerator HideLine()
    {
        yield return new WaitForSeconds(0.2f);
        line.enabled = false;
    }
}
