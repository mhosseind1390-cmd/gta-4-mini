using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float detectionRange = 30f;
    [SerializeField] private float shootRange = 20f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    
    private Transform player;
    private float shootCooldown = 0f;
    private float shootInterval = 1.5f;
    private bool isChasing = false;
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
        
        gameObject.tag = "Enemy";
    }
    
    private void Update()
    {
        if (!player) return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            isChasing = false;
            animator?.SetBool("IsRunning", false);
        }
        
        shootCooldown -= Time.deltaTime;
    }
    
    private void ChasePlayer(float distance)
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        rb.velocity = new Vector3(
            directionToPlayer.x * moveSpeed,
            rb.velocity.y,
            directionToPlayer.z * moveSpeed
        );
        
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
        animator?.SetBool("IsRunning", true);
        
        if (distance < shootRange && shootCooldown <= 0)
        {
            Shoot();
            shootCooldown = shootInterval;
        }
    }
    
    private void Shoot()
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
                    playerController.TakeDamage(10);
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
        GameManager.Instance.AddScore(50);
        GameManager.Instance.AddMoney(100);
        Destroy(gameObject);
    }
}
