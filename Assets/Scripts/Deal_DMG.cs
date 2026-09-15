using UnityEngine;

public class Deal_DMG : MonoBehaviour
{
    [SerializeField] GameMenu gameMenu;

    private void Awake()
    {
        gameMenu = FindAnyObjectByType<GameMenu>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameMenu.gamePaused == false)
        {
            // deal dmg TO the player
            collision.gameObject.GetComponentInParent<PlayerData>().current_HP -= GetComponent<EnemyData>().DMG * Time.deltaTime;

            // take dmg FROM the player
            GetComponent<EnemyData>().currentHP -= collision.gameObject.GetComponentInParent<PlayerData>().DMG * Time.deltaTime;
        }
    }
}
