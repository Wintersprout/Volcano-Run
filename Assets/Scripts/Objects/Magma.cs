using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : Rock
{
    [SerializeField]
    private GameObject explosionParticle;

    // Start is called before the first frame update
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
        
        GameObject explosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosion.transform.localScale = gameObject.transform.localScale;
    }
}
