using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    [SerializeField] Vector3 respawnPosition;
    [SerializeField] int respawnTime = 10;
    [SerializeField] Collider2D hazard;
    private int currentTime = 0;

    public void Respawn()
    {
        //play death animation
        currentTime = 1;
    }

    public void FixedUpdate()
    {
        if (currentTime > 1)
        {
            if (currentTime == respawnTime)
            {
                Debug.Log("Respawn");
                currentTime = 0;
            }
            else
            {
                currentTime = currentTime + 1;
            }
        }
        
        Collider2D.C
    }
}
