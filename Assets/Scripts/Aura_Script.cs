using UnityEngine;

public class Aura_Script : MonoBehaviour
{
    [SerializeField] GameMenu gameMenu;
    [SerializeField] float dmg = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameMenu.gamePaused == false)
        {
            collision.gameObject.GetComponent<EnemyData>().currentHP -= dmg * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameMenu.gamePaused == false)
        {
            collision.gameObject.GetComponent<EnemyData>().currentHP -= dmg * Time.deltaTime;
        }
    }
}
