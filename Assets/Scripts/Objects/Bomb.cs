using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody bombRb;

    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Throw();
    }

    public void Reset(Vector3 position)
    {
        bombRb.velocity = Vector3.zero;
        transform.position = position + new Vector3(0, 1.5f, -2.5f);
    }

    private void Throw()
    {
        Vector3 angle = new Vector3(0, 0.5f, -1).normalized;
        bombRb.AddForce(angle * moveSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    /*
    public float speed, timer = 2.0f;
    private Vector3 throwDirection = new Vector3(0, 0.5f, 1).normalized;
    
    private Rigidbody bombRb;
    private AudioSource bombAudio;
    
    [SerializeField]
    private GameObject explosion;

    private void Awake()
    {
        bombAudio = GetComponent<AudioSource>();
        bombRb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        Invoke("Explode", timer);
        bombRb.AddForce(throwDirection * speed, ForceMode.Impulse);
        bombAudio.Play();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            Explode();
    }
    
    private void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
    */
}
