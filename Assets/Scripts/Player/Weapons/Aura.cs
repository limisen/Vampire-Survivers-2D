using UnityEngine;

public class Aura : Weapons.Aura_Data
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.singleton.gamePaused == false && collision.gameObject.CompareTag("Enemy"))
        {
            // Deal dmg to the Enemy whilst inside of the Aura, do so over time (scaled to be per second not per frame)
            collision.gameObject.GetComponent<EnemyData>().currentHP -= DMG * Time.deltaTime;
        }
    }
}
