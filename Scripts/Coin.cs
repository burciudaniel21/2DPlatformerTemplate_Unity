using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public void Collect()
    {
        Debug.Log("Coin collected!");
        GameManager.Instance.UpdateScore(10); // Increase the score in the GameManager
        Destroy(gameObject);
    }
}
