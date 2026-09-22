using UnityEngine;

public class Deal_DMG : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (GameManager.singleton.gamePaused == false && collision.gameObject.CompareTag("Player"))
        {
            // Deal dmg to the player over time (scaled to be per second not per frame)
            collision.gameObject.GetComponent<PlayerData>().current_HP -= gameObject.GetComponent<EnemyData>().DMG * Time.deltaTime;
        }
    }
}
