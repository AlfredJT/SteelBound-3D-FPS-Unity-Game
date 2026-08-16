using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    [Header("Health UI")]
    public Slider HealthBar; // Reference to health bar slider

    // Patrol settings
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attack settings
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    // Detection ranges
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        HealthBar.maxValue = health; // Set max health
        HealthBar.value = health; // Initialize health bar
    }

    private void UpdateHealthUI()
    {
        if (HealthBar != null)
        {
            HealthBar.value = health; // Adjust slider based on current health
        }
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Stop enemy movement during attack
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack logic
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI(); // Update health bar visually

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }


    private void DestroyEnemy()
    {
        // Trigger the death effect before destroying the enemy
        EnemyDeathEffect deathEffect = GetComponent<EnemyDeathEffect>();
        if (deathEffect != null)
        {
            deathEffect.PlayDeathEffect();
        }
        Object.FindFirstObjectByType<EnemyManager>().EnemyDefeated();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AK47_Bullet")) // Bullet collision detection
        {
            TakeDamage(20); // Reduce health by 5 on hit
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
