using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    public float speed = 5f;

    public void Move() // This class "realises" the IMovement interface by implementing the Move() method
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector2(horizontal, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}