using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public Transform hungerBar;

    [HideInInspector] public int hunger = 1;
    private int maxHunger = 1;
    private Vector3 hungerBarFullScale;

    public void Initialize(int startingHunger)
    {
        hunger = Mathf.Max(1, startingHunger);
        maxHunger = hunger;

        if (hungerBar != null)
        {
            hungerBarFullScale = hungerBar.localScale;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Projectile"))
        {
            return;
        }

        other.gameObject.tag = "Untagged";
        Destroy(other.gameObject);

        hunger--;
        UpdateHungerBar();

        if (hunger > 0)
        {
            return;
        }

        PlayerController playerControllerScript = FindFirstObjectByType<PlayerController>();
        if (playerControllerScript != null)
        {
            playerControllerScript.AddScore(1);
        }

        Destroy(gameObject);
    }

    void UpdateHungerBar()
    {
        if (hungerBar == null)
        {
            return;
        }

        float hungerPercent = Mathf.Clamp01((float)hunger / maxHunger);
        hungerBar.localScale = new Vector3(
            hungerBarFullScale.x * hungerPercent,
            hungerBarFullScale.y,
            hungerBarFullScale.z);
    }
}
