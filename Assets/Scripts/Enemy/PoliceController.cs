using UnityEngine;

public class PoliceController : MonoBehaviour
{
    [SerializeField] private float chaseSpeed = 8f;
    [SerializeField] private float shootRange = 15f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float health = 80f;
    
    private Transform player;
    private float shootCooldown = 0f;
    private float shootInterval = 2f;
    private bool isChasingPlayer = false;
    private float currentHealth;
    
    private void Start()
    {
        currentHealth = health;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
        {
            player = playerObj.transform;
        }
        else
        {
            Destroy(gameObject);
        }
        
        gameObject.tag = "Police";
    }
    
    private void Update()
    {
        if (!player || GameManager.Instance.wantedLevel == 0)
        {
            Destroy(gameObject);
            return;
        }
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer < 50f)
        {
            isChasingPlayer = true;
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            isChasingPlayer = false;
            animator?.SetBool("IsRunning", false);
        }
        
        shootCooldown -= Time.deltaTime;
    }
    
    private void ChasePlayer(float distance)
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        rb.velocity = new Vector3(
            directionToPlayer.x * chaseSpeed,
            rb.velocity.y,
            directionToPlayer.z * chaseSpeed
        );
        
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
        animator?.SetBool("IsRunning", true);
        
        if (distance < shootRange && shootCooldown <= 0)
        {
            ShootAtPlayer();
            shootCooldown = shootInterval;
            
            // Increase wanted level
            GameManager.Instance.IncreaseWantedLevel();
        }
    }
    
    private void ShootAtPlayer()
    {
        Vector3 shootDirection = (player.position - transform.position).normalized;
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, shootDirection, out hit, shootRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                PlayerController playerController = hit.collider.GetComponent<PlayerController>();
                if (playerController)
                {
                    playerController.TakeDamage(15);
                }
            }
        }
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
        GameManager.Instance.AddMoney(500);
        GameManager.Instance.AddScore(100);
        if (GameManager.Instance.wantedLevel > 0)
        {
            GameManager.Instance.DecreaseWantedLevel();
        }
        Destroy(gameObject);
    }
}
