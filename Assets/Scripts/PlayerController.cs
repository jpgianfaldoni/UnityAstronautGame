using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _baseSpeed = 10.0f;
    public float _gravity = 9.8f;
    public CharacterController characterController;
    GameObject playerCamera;
    float cameraRotation;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
    }

    void Update()
    {
        float x,y,z;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        y=0;
        if(!characterController.isGrounded){
            y=-this._gravity;
        }

        float mouse_dX, mouse_dY;
        mouse_dX = Input.GetAxis("Mouse X");
        mouse_dY = Input.GetAxis("Mouse Y");

        cameraRotation-=mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);
        
        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * this._baseSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.up, mouse_dX);

        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }
}
