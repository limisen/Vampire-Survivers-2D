using UnityEngine;

public class MissileMovement : weapon
{
    [SerializeField] float moveSpeed;

    GameObject Enemy;

    private void Awake()
    {
        // initalise dmg
        Enemy = FindAnyObjectByType<EnemyData>().gameObject;
    }

    private void Update()
    {
        if (Enemy == null)
        {
            Enemy = FindAnyObjectByType<EnemyData>().gameObject;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            // calculate(ed) distance between this object and the target object
            Vector3 delta = Enemy.transform.position - transform.position;

            // make sure not to move closer on the Z-Axis
            delta.z = 0;

            // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
            delta.Normalize();

            // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
            float angle_to_rotate = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            // Now set the position and then rotate so we are facing the target (aka the player)
            transform.SetPositionAndRotation((transform.position += (Time.deltaTime * moveSpeed) * delta), Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.singleton.gamePaused == false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Magic missile and Enemy collision detected");
                collision.gameObject.GetComponent<EnemyData>().currentHP -= dmg;
                Destroy(gameObject);
            }
        }
    }
}
