using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float health = 100f;
    [SerializeField] private Camera mainCamera;
    
    private Vector3 moveDirection;
    private bool isArmed = false;
    private bool isInCar = false;
    private GameObject currentWeapon;
    private CarController currentCar;
    private float currentHealth;
    
    private void Start()
    {
        currentHealth = health;
        gameObject.tag = "Player";
        
        if (!mainCamera)
            mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (GameManager.Instance.IsPaused || isInCar)
            return;
        
        HandleMovement();
        HandleRotation();
        HandleWeapon();
        HandleInteraction();
    }
    
    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        
        if (moveDirection.magnitude > 0.1f)
        {
            rb.velocity = new Vector3(
                moveDirection.x * moveSpeed,
                rb.velocity.y,
                moveDirection.z * moveSpeed
            );
            
            animator?.SetBool("IsRunning", true);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            animator?.SetBool("IsRunning", false);
        }
    }
    
    private void HandleRotation()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 directionToMouse = (hitPoint - transform.position).normalized;
            
            if (directionToMouse.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    
    private void HandleWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupWeapon();
        }
        
        if (Input.GetMouseButton(0) && isArmed)
        {
            Shoot();
        }
    }
    
    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnterCar();
        }
    }
    
    private void PickupWeapon()
    {
        isArmed = !isArmed;
        if (currentWeapon)
        {
            currentWeapon.SetActive(isArmed);
        }
        Debug.Log(isArmed ? "Weapon equipped" : "Weapon holstered");
    }
    
    private void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (enemy)
                {
                    enemy.TakeDamage(25);
                    GameManager.Instance.AddScore(10);
                }
            }
            else if (hit.collider.CompareTag("Police"))
            {
                PoliceController police = hit.collider.GetComponent<PoliceController>();
                if (police)
                {
                    police.TakeDamage(25);
                    GameManager.Instance.AddScore(50);
                    GameManager.Instance.DecreaseWantedLevel();
                }
            }
        }
    }
    
    private void EnterCar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        
        foreach (Collider collider in colliders)
        {
            CarController car = collider.GetComponent<CarController>();
            if (car)
            {
                isInCar = true;
                currentCar = car;
                car.PlayerEnter(transform);
                animator?.SetBool("IsRunning", false);
                rb.velocity = Vector3.zero;
                break;
            }
        }
    }
    
    public void ExitCar()
    {
        if (currentCar)
        {
            currentCar.PlayerExit();
            currentCar = null;
        }
        isInCar = false;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("Player died!");
        GameManager.Instance.GameOver();
    }
    
    public float GetHealth() => currentHealth;
    public bool IsInCar => isInCar;
}
