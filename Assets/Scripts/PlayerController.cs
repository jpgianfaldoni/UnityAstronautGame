using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float _baseSpeed = 0.5f;
    private float _mouseSensitivity = 250.0f;
    private CharacterController characterController;
    private GameObject playerCamera;
    private Light flashlight;
    private float cameraRotation;
    private Vector3 direction = Vector3.zero;
    public ParticleSystem emitter;
    private bool emitting = false;

    public GameObject yawPointer, pitchPointer;
    public Text speedText;
    private float yaw, pitch;


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
        if(Input.GetMouseButton(0)){
            if(FindObjectOfType<GameManager>().fuel > 0) {
                if (!emitting){
                    emitter.Play();
                }
                FindObjectOfType<GameManager>().useFuel();
                direction += playerCamera.transform.forward * -this._baseSpeed;
                emitting = true;
            } else {
                if (emitting){
                    emitter.Stop();
                }
                emitting = false;
            }
        } else {
            if (emitting){
                emitter.Stop();
            }
            emitting = false;
            if (Input.GetButton("Jump")){
                if(FindObjectOfType<GameManager>().fuel > 0){
                    // Consume more fuel the faster you're going
                    int cost = ((int)direction.magnitude) / 10 + 1;
                    if(FindObjectOfType<GameManager>().fuel > 0){
                        FindObjectOfType<GameManager>().useFuel(cost);
                        direction = Vector3.zero;
                    }
                }
            }
        }
        direction = Vector3.ClampMagnitude(direction, 100.0f);
        speedText.text = direction.magnitude.ToString("0");

        characterController.Move(direction * Time.deltaTime);
        this.transform.Rotate(Vector3.up, mouse_dX);
        this.transform.Rotate(Vector3.right, -mouse_dY);
        this.yaw += mouse_dX;
        this.pitch-=mouse_dY;
        this.yaw = this.yaw%360;
        this.pitch = this.pitch%360;
        
        yawPointer.transform.eulerAngles = new Vector3(0,0,this.yaw);
        pitchPointer.transform.eulerAngles = new Vector3(0,0,this.pitch);       

        // playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        // flashlight.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }
}
