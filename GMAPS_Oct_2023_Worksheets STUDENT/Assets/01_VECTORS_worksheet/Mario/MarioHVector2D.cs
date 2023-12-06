using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);
        gravityDir.Normalize();
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        moveDir.Normalize();

        gravityNorm = gravityDir;

        rb.AddForce(gravityDir.ToUnityVector2() * gravityStrength);
        rb.AddForce(-moveDir.ToUnityVector2() * force);

        HVector2D down = new HVector2D(0, -1);

        float angle = Mathf.Rad2Deg * gravityDir.FindAngle(down);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));
    }
}