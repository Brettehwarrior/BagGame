using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundedFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;
    
    private void LateUpdate()
    {
        var position = transform.position;
        Vector3 desiredPosition = target.position;
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x), Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y), position.z);
        Vector3 smoothedPosition = Vector3.Lerp(position, clampedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3((minBounds.x + maxBounds.x) / 2, (minBounds.y + maxBounds.y) / 2, 0), new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 1));
    }
}
