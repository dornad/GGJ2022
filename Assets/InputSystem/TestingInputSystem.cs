using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour {

    [SerializeField]
    public float amount = 5.0f;
    private Rigidbody cameraRigidbody;

    private void Awake() {
        cameraRigidbody = GetComponent<Rigidbody>();
    }
    public void Jump(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Jump!");
            cameraRigidbody.AddForce(Vector3.up * amount, ForceMode.Impulse);
        }
    }
}
