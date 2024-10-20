using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    public float speed;

    public virtual void Move(float direction)
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die(); // Must be implemented by subclasses
}
