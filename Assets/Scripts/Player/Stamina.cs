using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public readonly float maxStamina = 100;
    public float currentStamina;
    
    [SerializeField]
    private float decreaseRate;

    [SerializeField]
    private AudioClip recoverAudio;

    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
        LoseStamina(decreaseRate * Time.deltaTime);
    }

    public void LoseStamina(float amount)
    {
        if (!GameManager.game.gameOver)
        {
            currentStamina -= amount;
            if (currentStamina <= 0)
            {
                GameManager.game.LoseGame();
            }
        }
    }

    public void RecoverStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        var playerAudioSource = GetComponent<AudioSource>();
        if (playerAudioSource != null)
            playerAudioSource.PlayOneShot(recoverAudio);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lose stamina and show particles if collide with an obstacle
        var obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            var damageParticle = GetComponentInChildren<ParticleSystem>(true);

            if (damageParticle != null)
            {
                damageParticle.gameObject.SetActive(true);
                damageParticle.Play();
            }
            LoseStamina(obstacle.damageRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
            RecoverStamina(other.GetComponent<PickUp>().restoreRate);
    }
}
