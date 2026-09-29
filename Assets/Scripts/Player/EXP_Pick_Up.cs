using UnityEngine;

public class EXP_Pick_Up : MonoBehaviour
{
    public int EXP_to_give;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the EXP_ORB and Player collide increase player's exp by the orbs EXP Value and then destroy that EXP orb
            GameManager.singleton.current_EXP = EXP_to_give;

            // Destroy the EXP_ORB
            Destroy(gameObject);
        }
    }
}
