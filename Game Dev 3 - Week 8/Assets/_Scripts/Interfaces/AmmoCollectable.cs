using UnityEngine;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Interfaces
{
    public class AmmoCollectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private int ammoAmount = 10; // Amount of ammo to refill
        [SerializeField] Player_Shooting shootingScript;
        [SerializeField] AudioSource reloadSound;

        private void OnCollisionEnter(Collision collision)
        {
            // Check if the collider belongs to the player
            if (collision.gameObject.tag == ("PlayerParts"))
            {
                reloadSound.Play();
                Collect(collision.gameObject);
            }
        }


        public void Collect(GameObject player)
        {
            // Attempt to get the Player_Shooting component from the player object
            if (shootingScript != null)
            {
                // Refill ammo and destroy the collectable
                shootingScript.RefillAmmo(ammoAmount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Player does not have a Player_Shooting component!");
            }
        }

        
    }
}
