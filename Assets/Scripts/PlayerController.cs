using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float _baseSpeed = 0.5f;
    private float _mouseSensitivity = 4.5f;
    private CharacterController characterController;
    private GameObject playerCamera;
    private Light flashlight;
    private float cameraRotation;
    private Vector3 direction = Vector3.zero;
    public ParticleSystem emitter;
    private bool emitting = false;

    public GameObject yawPointer, pitchPointer;
    private GameObject goal;
    public Text speedText, distanceText, timerText;
    private float yaw, pitch;

    public float _timeRemaining = 60;

    public AudioSource gasRelease, warning, gasReleaseSpace;

    private bool playWarning = true;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        characterController = GetComponent<CharacterController>();
        flashlight = GetComponentInChildren<Light>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        if(gm.getMouseState()){
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
        }
        goal = GameObject.FindGameObjectWithTag("Finish");
    }

    void updateTimer(){

        if(this._timeRemaining > 0){
            this._timeRemaining -= Time.deltaTime;
            if(this._timeRemaining < 20 && playWarning == true){
                warning.Play();
                timerText.color = Color.red;
                playWarning = false;
            }
        } else {
            // Time ran out
            Debug.Log("Time is up!");
            this._timeRemaining = 0f;
            gm.GameOver();   
        }
        float minutes = Mathf.FloorToInt(this._timeRemaining / 60);
        float seconds = Mathf.FloorToInt(this._timeRemaining % 60);
        float milliseconds = (this._timeRemaining%1)*1000;
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    void updateDistance(){
        float dist = Vector3.Distance(this.gameObject.transform.position, this.goal.transform.position);
        this.distanceText.text = string.Format("Distance to goal: {0:0}m", dist);
    }

    void checkFuel(){
        if (FindObjectOfType<FuelManager>().fuel <= 0){
            gm.GameOver();
        }
    }

    void checkRestart(){
        if(Input.GetKeyDown(KeyCode.Backspace)){
            // gm.RestartLevel();
            gm.NextLevel();
        }
    }

    void checkQuit(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            gm.QuitGame();
        }   
    }

    void Update()
    {
        updateTimer();
        updateDistance();
        checkFuel();
        checkRestart();
        checkQuit();

        if(Input.GetMouseButton(0)){
            if(FindObjectOfType<FuelManager>().fuel > 0) {
                if (!emitting){
                    emitter.Play();
                    gasRelease.Play();
                }
                FindObjectOfType<FuelManager>().useFuel();
                direction += playerCamera.transform.forward * -this._baseSpeed;
                emitting = true;
            } else {
                if (emitting){
                    gasRelease.Stop();
                    emitter.Stop();
                }
                emitting = false;
            }
        } else {
            if (emitting){
                gasRelease.Stop();
                emitter.Stop();
            }
            emitting = false;
            if (Input.GetButtonDown("Jump")){
                if(FindObjectOfType<FuelManager>().fuel > 0){
                    // Consume more fuel the faster you're going
                    int cost = ((int)direction.magnitude) / 10 + 1;
                    if(FindObjectOfType<FuelManager>().fuel > 0){
                        FindObjectOfType<FuelManager>().useFuel(cost);
                        direction = Vector3.zero;
                        gasReleaseSpace.Play();
                    }
                }
            }
        }
        
        direction = Vector3.ClampMagnitude(direction, 100.0f);
        speedText.text = "Speed: " + direction.magnitude.ToString("0");
        characterController.Move(direction * Time.deltaTime);      

        // playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        // flashlight.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }

    private void FixedUpdate() {
        float mouse_dX, mouse_dY;
        mouse_dX = Input.GetAxis("Mouse X") * this._mouseSensitivity;
        mouse_dY = Input.GetAxis("Mouse Y") * this._mouseSensitivity;
        cameraRotation -= mouse_dY;
        this.transform.Rotate(Vector3.up, mouse_dX);
        this.transform.Rotate(Vector3.right, -mouse_dY);
        this.yaw += mouse_dX;
        this.pitch -= mouse_dY;
        this.yaw = this.yaw%360;
        this.pitch = this.pitch%360;
        yawPointer.transform.eulerAngles = new Vector3(0,0,this.yaw);
        pitchPointer.transform.eulerAngles = new Vector3(0,0,this.pitch); 
    }
}
