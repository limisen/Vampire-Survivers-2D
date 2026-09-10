using UnityEngine;

public class EXP_Pick_Up : MonoBehaviour
{
    public int EXP_to_give = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerData>().current_EXP += EXP_to_give;

            Destroy(gameObject);
        }
    }
}
