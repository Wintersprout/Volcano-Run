using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : Obstacle
{
    [SerializeField]
    private GameObject explosionParticle;

    // Start is called before the first frame update
    private void OnEnable()
    {
        ResetVelocity();
        RandomizeSize(minimumMass, maximumMass);
        //ApplyRandomTorque(Random.Range(-initialTorqueRange, initialTorqueRange));
        ApplyRandomImpulse(moveSpeed);
    }

    protected override void ApplyRandomImpulse(float impulseStrenght)
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 1).normalized;
        obstacleRb.AddForce(direction * moveSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponentInParent<ObjectPool>().ReturnObject(gameObject);

        GameObject explosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosion.transform.localScale = gameObject.transform.localScale;
    }
}
