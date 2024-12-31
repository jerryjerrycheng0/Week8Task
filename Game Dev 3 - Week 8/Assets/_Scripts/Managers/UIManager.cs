using UnityEngine;
using TMPro;
using GameDevWithMarco.Player;
using GameDevWithMarco.Enemy;

namespace GameDevWithMarco.UI
{
        public class UIManager : MonoBehaviour
        {
            [Header("UI References")]
            [SerializeField] TMP_Text ammoText;       // Reference to the Ammo UI Text
            [SerializeField] TMP_Text zombieCountText; // Reference to the Zombie Count UI Text

            [Header("Player and Game References")]
            [SerializeField] Player_Shooting playerShooting; // Reference to the Player Shooting script

            private int totalZombies; // Tracks the total number of zombies in the scene

            private void Start()
            {
                // Auto-assign playerShooting if not set
                if (playerShooting == null)
                {
                    playerShooting = FindObjectOfType<Player_Shooting>();
                }

                // Count the initial number of zombies
                totalZombies = FindObjectsOfType<Zombie_Parent>().Length;

                // Update the UI for the first time
                UpdateAmmoUI();
                UpdateZombieCountUI();
            }

            private void Update()
            {
                // Continuously update the ammo count
                UpdateAmmoUI();
            }

            public void UpdateAmmoUI()
            {
                if (ammoText != null && playerShooting != null)
                {
                    ammoText.text = $"Ammo: {playerShooting.currentAmmo}";
                }
            }

            public void DecrementZombieCount()
            {
                totalZombies--;
                UpdateZombieCountUI();
            }

            private void UpdateZombieCountUI()
            {
                if (zombieCountText != null)
                {
                    zombieCountText.text = $"Zombies Left: {totalZombies}";
                }
            }
        }
    }

