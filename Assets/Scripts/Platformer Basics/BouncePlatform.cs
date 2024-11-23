using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2DJump player;
    [SerializeField]
    float force;
    int cooldown = 1;
    [SerializeField]
    private int maxCooldown = 60;

    private void FixedUpdate()
    {
        if( cooldown > 0)
        {
            cooldown--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cooldown == 0)
        {
            cooldown = maxCooldown;
            player.Bounce(transform.up, force);
        }
    }
}
