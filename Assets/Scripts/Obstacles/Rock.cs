using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Obstacle
{

    private void OnEnable()
    {
        ResetVelocity();
        RandomizeSize(minimumMass, maximumMass);
        ApplyRandomTorque(Random.Range(-initialTorqueRange, initialTorqueRange));
        ApplyRandomImpulse(moveSpeed);
    }

    private void Update()
    {
        ApplyPull(moveSpeed);
    }

    private void ApplyPull(float pullForce)
    {
        float resultingForce = pullForce - PlayerCharacter.scrollSpeed;
        obstacleRb.AddForce(Vector3.forward * resultingForce);
    }
}
