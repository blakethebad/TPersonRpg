using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWithTarget : Projectile
{
    Vector3 MovementVector;
    public float DamageAmount { get; set; }
    public Transform TargetTransform { get; set; }

    private void FixedUpdate()
    {

        if (isTraveling)
        {
            Vector3 direction = (TargetTransform.position - transform.position).normalized;
            MovementVector = direction * Time.fixedDeltaTime * ProjectileSpeed;
            transform.Translate(MovementVector); 
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        MovementVector = Vector3.zero;
        isTraveling = false;
        Destroy(this.gameObject);

    }
}
