using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMenu : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentYaw = 0f;

    void Update()
    {
        currentYaw -= 1 * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
       
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
        currentYaw = -yawSpeed;
    }
}
