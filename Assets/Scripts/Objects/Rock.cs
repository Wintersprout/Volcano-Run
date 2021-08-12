using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Obstacle
{
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float minimumMass = 1.0f, maximumMass = 10.0f;
    protected float initialTorqueRange = 5;
    protected Rigidbody obstacleRb;

    void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }

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

    protected virtual void RandomizeSize(float min, float max)
    {
        float randomMass = Random.Range(min, max);
        float randomScale = randomMass / 2;

        obstacleRb.mass = randomMass;
        GetComponent<Transform>().localScale = new Vector3(randomScale, randomScale, randomScale);
    }
    protected void ApplyRandomTorque(float magnitude)
    {
        Vector3 torqueVector = GenerateRandomVector();
        obstacleRb.AddTorque(torqueVector * magnitude, ForceMode.Impulse);
    }
    protected virtual void ApplyRandomImpulse(float impulseStrenght)
    {
        Vector3 direction = GenerateRandomVector();
        obstacleRb.AddForce(direction * impulseStrenght, ForceMode.Impulse);
    }

    protected void ResetVelocity()
    {
        obstacleRb.velocity = Vector3.zero;
        obstacleRb.angularVelocity = Vector3.zero;
    }

    protected Vector3 GenerateRandomVector()
    {
        return new Vector3(
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f)).normalized;
    }
}
