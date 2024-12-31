using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevWithMarco.Others
{
    public class OutOfBounds : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            SceneManager.LoadScene(0);
        }
    }
}
