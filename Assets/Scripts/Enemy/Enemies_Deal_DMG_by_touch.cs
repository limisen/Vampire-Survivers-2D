using UnityEngine;

public class Enemies_Deal_DMG_by_touch : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (GameManager.singleton.gamePaused == false && collision.gameObject.CompareTag("Enemy"))
        {
            // Deal dmg to the player over time (scaled to be per second not per frame)
            GameManager.singleton.Player_current_HP -= collision.gameObject.GetComponent<EnemyData>().DMG * Time.deltaTime;
        }
    }
}
