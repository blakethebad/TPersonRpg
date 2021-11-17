using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectProjectile : Projectile
{
    public Vector3 Direction { get; set; }
    public float MaxLifeTime { get; set; }
    float currentLifeTime;


    private void Update()
    {
        if (currentLifeTime < MaxLifeTime)
        {
            currentLifeTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (currentLifeTime < MaxLifeTime)
        {

            if (isTraveling)
            {
                Vector3 Movement = Direction * Time.fixedDeltaTime * ProjectileSpeed;
                transform.Translate(Movement);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        isTraveling = false;
        Destroy(this.gameObject);
    }
}
