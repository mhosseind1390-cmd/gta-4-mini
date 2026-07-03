using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float accelerationForce = 100f;
    [SerializeField] private float brakingForce = 50f;
    [SerializeField] private float steeringSpeed = 3f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRotationSpeed = 10f;
    
    private float currentSpeed = 0f;
    private float steeringInput = 0f;
    private bool isPlayerInside = false;
    private PlayerController playerController;
    private float engineSoundTimer = 0f;
    
    private void Update()
    {
        if (!isPlayerInside) return;
        
        HandleInput();
        HandleSteering();
        HandleWheelRotation();
        HandleExitCar();
    }
    
    private void FixedUpdate()
    {
        if (!isPlayerInside) return;
        HandleAcceleration();
    }
    
    private void HandleInput()
    {
        float accelerationInput = Input.GetAxis("Vertical");
        float brakeInput = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        steeringInput = Input.GetAxis("Horizontal");
        
        if (accelerationInput > 0)
        {
            currentSpeed = Mathf.Min(currentSpeed + accelerationForce * Time.deltaTime, maxSpeed);
        }
        else if (accelerationInput < 0)
        {
            currentSpeed = Mathf.Max(currentSpeed - accelerationForce * Time.deltaTime, -maxSpeed / 2);
        }
        else if (brakeInput > 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, brakingForce * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 2f * Time.deltaTime);
        }
    }
    
    private void HandleAcceleration()
    {
        Vector3 moveDirection = transform.forward * currentSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }
    
    private void HandleSteering()
    {
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            transform.Rotate(0, steeringInput * steeringSpeed, 0);
        }
    }
    
    private void HandleWheelRotation()
    {
        if (wheels.Length == 0) return;
        
        foreach (Transform wheel in wheels)
        {
            if (wheel)
            {
                wheel.Rotate(wheelRotationSpeed * currentSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
    
    private void HandleExitCar()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ExitCar();
        }
    }
    
    public void PlayerEnter(Transform playerTransform)
    {
        isPlayerInside = true;
        playerController = playerTransform.GetComponent<PlayerController>();
        
        if (playerController)
        {
            playerTransform.parent = transform;
            playerTransform.localPosition = Vector3.zero;
        }
    }
    
    public void ExitCar()
    {
        isPlayerInside = false;
        currentSpeed = 0;
        
        if (playerController)
        {
            playerController.transform.parent = null;
            playerController.transform.position = transform.position + transform.right * 2f;
            playerController.ExitCar();
            playerController = null;
        }
    }
    
    public float GetCurrentSpeed() => currentSpeed;
    public bool IsPlayerInside => isPlayerInside;
}
