using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab; // Assign a bullet prefab in the inspector
        public Transform bulletSpawnPoint; // Where the bullet spawns
        public Transform bulletSpawnPointTwo;
        public float fireRate = 0.5f; // Time between shots
        [SerializeField] AudioClip bulletSound;
        [SerializeField] AudioSource bulletSource;
        [SerializeField] AudioSource noAmmo;

        private float nextFireTime;

        public int currentAmmo = 100; // Initial ammo count
        public int maxAmmo = 200;    // Maximum ammo capacity

        private void Start()
        {
            if (bulletSource == null)
            {
                bulletSource = GetComponent<AudioSource>();
                bulletSource.pitch = Random.Range(0.7f, 0.1f);
            }

            if (bulletSound != null)
            {
                bulletSource.clip = bulletSound;
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime && currentAmmo > 0)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
                bulletSource.PlayOneShot(bulletSound, 0.2f);
                currentAmmo--; // Decrease ammo after each shot

                if(currentAmmo <= 0)
                {
                    noAmmo.Play();
                }
            }
        }

        private void Shoot()
        {
            // Instantiate the bullet at the spawn point with the player's rotation
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Instantiate(bulletPrefab, bulletSpawnPointTwo.position, bulletSpawnPointTwo.rotation);
        }

        // Refill ammo, ensuring it doesn't exceed max capacity
        public void RefillAmmo(int amount)
        {
            currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        }
    }
}
