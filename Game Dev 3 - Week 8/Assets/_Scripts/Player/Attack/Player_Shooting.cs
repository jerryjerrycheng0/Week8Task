using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab; // Assign a bullet prefab in the inspector
        public Transform bulletSpawnPoint; // Where the bullet spawns
        public float fireRate = 0.5f; // Time between shots

        private float nextFireTime;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }

        private void Shoot()
        {
            // Instantiate the bullet at the spawn point with the player's rotation
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
