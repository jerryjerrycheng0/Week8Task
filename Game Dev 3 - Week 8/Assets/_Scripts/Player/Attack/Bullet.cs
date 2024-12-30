using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public float lifetime = 5f; // Destroy after 5 seconds if no collision
        public GameObject impactEffect; // Optional: Effect on impact

        private Player_Audio playerAudioScript;

        private void Start()
        {
            Destroy(gameObject, lifetime);

            playerAudioScript = FindObjectOfType<Player_Audio>();
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Zombie"))
            {
                // Optional: Instantiate an impact effect
                if (impactEffect != null)
                {
                    Instantiate(impactEffect, transform.position, Quaternion.identity);
                }
                playerAudioScript.PlayGargleSound();
                // Destroy the zombie
                Destroy(collision.gameObject);
            }

            // Destroy the bullet on any collision
            Destroy(gameObject);
        }
    }
}
