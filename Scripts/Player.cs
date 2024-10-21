using UnityEngine;

public class Player : Character
{
    private IMove movement;
    public Weapon equippedWeapon; // Aggregation: Weapon can exist independently

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
        if (Input.GetButtonDown("Fire1") && equippedWeapon != null)
        {
            UseWeapon();
        }
    }
    public void UseWeapon()
    {
        equippedWeapon.UseWeapon(); // Aggregated weapon is used by the player
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

        Weapon newWeapon = other.GetComponent<Weapon>();
        if (newWeapon != null)
        {
            EquipWeapon(newWeapon); // Equip the weapon when collected
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        equippedWeapon = newWeapon;
        Debug.Log("Player equipped a new weapon!");
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
