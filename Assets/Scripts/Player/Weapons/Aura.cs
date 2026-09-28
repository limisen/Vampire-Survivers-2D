using UnityEngine;

public class Aura : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = GameManager.singleton.radius;
    }

    private void Update()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = GameManager.singleton.radius;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.singleton.gamePaused == false && collision.gameObject.CompareTag("Enemy"))
        {
            // Deal dmg to the Enemy whilst inside of the Aura, do so over time (scaled to be per second not per frame)
            collision.gameObject.GetComponent<EnemyData>().currentHP -= GameManager.singleton.Aura_DMG * Time.deltaTime;
        }
    }
}
