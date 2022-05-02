using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float _baseSpeed = 10.0f;
    private float _mouseSensitivity = 250.0f;
    private CharacterController characterController;
    private GameObject playerCamera;
    private Light flashlight;
    private float cameraRotation;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        flashlight = GetComponentInChildren<Light>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {


        float mouse_dX, mouse_dY;
        mouse_dX = Input.GetAxis("Mouse X") * this._mouseSensitivity * Time.deltaTime;
        mouse_dY = Input.GetAxis("Mouse Y") * this._mouseSensitivity * Time.deltaTime;

        cameraRotation-=mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);
        
        Vector3 direction = playerCamera.transform.forward;
        if (Input.GetButton("Jump")){
            direction *= this._baseSpeed;
        } else {
            direction *= 0;
        }
        characterController.Move(direction * Time.deltaTime);
        this.transform.Rotate(Vector3.up, mouse_dX);
        this.transform.Rotate(Vector3.right, -mouse_dY);
        

        // playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        // flashlight.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }
}
