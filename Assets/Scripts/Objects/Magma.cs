using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : Rock
{

    protected override void OnEnable()
    {
        ResetVelocity();
        RandomizeSize(minimumMass, maximumMass);
        //ApplyRandomTorque(Random.Range(-initialTorqueRange, initialTorqueRange));
        ApplyRandomImpulse(moveSpeed);
    }

    protected override void Update()
    {
        //base.Update();
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
