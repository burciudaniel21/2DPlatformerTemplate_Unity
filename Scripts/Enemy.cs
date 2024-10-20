using UnityEngine;

public class Enemy : Character
{
    public int damage;
    public float patrolDistance = 5f;  // How far the enemy patrols left and right
    private float startPositionX;      // The initial position of the enemy
    private bool movingRight = true;   // Direction the enemy is currently moving

    private void Start()
    {
        // Store the initial X position of the enemy
        startPositionX = transform.position.x;
    }

    private void Update()
    {
        Patrol();
    }

    // Method for patrolling behavior
    private void Patrol()
    {
        // Calculate the current patrol direction and move accordingly
        float direction = movingRight ? 1 : -1;
        Move(direction);

        // Check if the enemy has reached the patrol boundaries
        if (movingRight && transform.position.x > startPositionX + patrolDistance)
        {
            movingRight = false;  // Start moving left
        }
        else if (!movingRight && transform.position.x < startPositionX - patrolDistance)
        {
            movingRight = true;  // Start moving right
        }
    }

    // Handle collisions with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Attack(player);
        }
    }

    // Handle what happens when the enemy attacks the player
    public void Attack(Player player)
    {
        player.TakeDamage(damage);
        Debug.Log("Player took damage from enemy!");
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        // Draw patrol boundaries in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(startPositionX - patrolDistance, transform.position.y),
                        new Vector2(startPositionX + patrolDistance, transform.position.y));
    }

}
