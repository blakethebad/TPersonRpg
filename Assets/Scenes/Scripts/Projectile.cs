using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected bool isTraveling = true;
    public float ProjectileSpeed { get; set; }
    public Vector3 ProjectileOrigin { get; set; }

    private void Start()
    {
        transform.position = ProjectileOrigin;
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Projectile hit {other.name}");
    }
}
