using UnityEngine;

public class Player : Character
{
    private IMove movement;

    private void Start()
    {
       movement = GetComponent<IMove>();
    }

    private void Update()
    {
        movement.Move();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IItem item = other.GetComponent<IItem>();
        if (item != null)
        {
            CollectItem(item);
        }
    }

    public void CollectItem(IItem item)
    {
        item.Collect();
        Debug.Log("Player Score: " + GameManager.Instance.playerScore);
    }

    public override void TakeDamage(int damage)
    {
        GameManager.Instance.UpdateHealth(-damage); // Reduce health in the GameManager
        Debug.Log("Player Health: " + GameManager.Instance.player.health);
    }

    protected override void Die()
    {
        Debug.Log("Player died!");
        GameManager.Instance.RestartGame(); // Handle restart through GameManager
    }
}
