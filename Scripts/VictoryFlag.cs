using UnityEngine;

public class VictoryFlag : MonoBehaviour, IItem
{
    public void Collect()
    {
        Debug.Log("Player won the game!");

        // Call the GameManager to handle winning the game
        GameManager.Instance.PlayerWins();

        // Remove the win item from the scene
        Destroy(gameObject);
    }
}
