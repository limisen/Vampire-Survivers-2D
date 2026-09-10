using UnityEngine;

public class Deal_DMG : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // deal dmg TO the player
            collision.gameObject.GetComponentInParent<PlayerData>().current_HP -= GetComponent<EnemyData>().DMG;

            // take dmg FROM the player
            GetComponent<EnemyData>().currentHP -= collision.gameObject.GetComponentInParent<PlayerData>().DMG;
        }
    }
}
