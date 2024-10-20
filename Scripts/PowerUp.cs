using UnityEngine;

public class PowerUp : MonoBehaviour, IItem
{
    public void Collect()
    {
        Debug.Log("PowerUp collected!");
        // Grant power-up, like increased speed or health
        Destroy(gameObject);
    }
}
