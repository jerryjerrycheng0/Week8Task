using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Movement : MonoBehaviour
    {
        // Reference to the sphere's rigidbody
        public Rigidbody sphereRb;

        // Car driving variables
        public float forwardAccell = 8f;
        public float reverseAccel = 4f;
        public float maxSpeed;
        public float turnSrenght = 180f;
        public float gravityForce = 10f;
        private float dragOnValue = 3f;

        // Grounded Variables
        public bool grounded;
        public LayerMask whatIsGround;
        public float groundRayLenght = 0.5f;
        public Transform groundRayPoint;

        // Inputs for controls
        public float speedInput;
        public float turnInput;

        // Wheels variables
        public Transform leftFrontWheel, rightFrontWheel;
        public float maxWheelTurn = 25f;

        // Audio variables
        [SerializeField] AudioSource carMoveAudio;   // Reference to the AudioSource component
        [SerializeField] AudioClip carMoveClip;      // Reference to the car move sound clip

        // Start is called before the first frame update
        void Start()
        {
            sphereRb.transform.parent = null;

            // Ensure the audio source is set up correctly
            if (carMoveAudio == null)
            {
                carMoveAudio = GetComponent<AudioSource>();
                carMoveAudio.pitch = 1f;
            }

            if (carMoveClip != null)
            {
                carMoveAudio.clip = carMoveClip;
            }
        }

        // Update is called once per frame
        void Update()
        {
            AccellerationDecelleration();

            if (grounded)
            {
                Turning();
            }

            WheelsRotation();

            SetPositionToBeSameAsSphere();

            // Check if the player is moving (either forward or backward)
            HandleMovementAudio();
        }

        private void FixedUpdate()
        {
            GroundCheck();

            if (grounded)
            {
                AccelleratioForce();
            }
            else
            {
                PushCarDownToGround();
            }
        }

        public void PushCarDownToGround()
        {
            sphereRb.drag = 0.1f; // Reduces the drag, making the car continue to move in the air
            sphereRb.AddForce(Vector3.up * -gravityForce * 1000);
        }

        private void GroundCheck()
        {
            grounded = false;
            RaycastHit hit;

            if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLenght, whatIsGround))
            {
                grounded = true;

                // Adjusts the car rotation to match the slope
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }
        }

        private void WheelsRotation()
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn), rightFrontWheel.localRotation.eulerAngles.z);
        }

        private void AccelleratioForce()
        {
            sphereRb.drag = dragOnValue; // Restores the drag to the original value

            if (Mathf.Abs(speedInput) > 0)
            {
                sphereRb.AddForce(transform.forward * speedInput);
            }
        }

        private void SetPositionToBeSameAsSphere()
        {
            transform.position = sphereRb.transform.position;
        }

        public void Turning()
        {
            turnInput = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnSrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        public void AccellerationDecelleration()
        {
            speedInput = 0;

            if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * forwardAccell * 500;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                speedInput = Input.GetAxis("Vertical") * reverseAccel * 500;
            }
        }

        // Handle movement audio (playing when moving, stopping when idle)
        private void HandleMovementAudio()
        {
            if (Mathf.Abs(speedInput) > 0 && !carMoveAudio.isPlaying)
            {
                // Play the sound if the player starts moving and the sound isn't already playing
                carMoveAudio.Play();
            }
            else if (Mathf.Abs(speedInput) == 0 && carMoveAudio.isPlaying)
            {
                // Stop the sound if the player stops moving
                carMoveAudio.Stop();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                carMoveAudio.pitch = 1.5f;
            }
        }

    }
}
