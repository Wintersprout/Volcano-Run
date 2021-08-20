using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Magma class has hardcoded values
public class Magma : Rock
{
    protected override void OnEnable()
    {
        ResetVelocity();
        RandomizeSize(minimumMass, maximumMass);
        // TODO: As it is, ApplyRandomTorque would mess with this object's ParticleSystem
        //ApplyRandomTorque(Random.Range(-initialTorqueRange, initialTorqueRange));
        ApplyRandomImpulse(moveSpeed);
    }

    // Overriding the base class' ApplyPull
    protected override void Update()
    {
        
    }

    protected override void ApplyRandomImpulse(float impulseStrenght)
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, 1).normalized;
        obstacleRb.AddForce(direction * moveSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponentInParent<MagmaPool>().Remove(gameObject);
    }
}
