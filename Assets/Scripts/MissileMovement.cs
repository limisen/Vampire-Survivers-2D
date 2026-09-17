using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    GameObject Enemy;
    GameObject Player;

    private void Awake()
    {
        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.singleton.gamePaused == false && Enemy != null)
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
        if (GameManager.singleton.gamePaused == false && Enemy == null)
        {
            // calculate(ed) distance between this object and the target object
            Vector3 delta = Player.transform.position - transform.position;

            // make sure not to move closer on the Z-Axis
            delta.z = 0;

            // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
            delta.Normalize();

            // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
            float angle_to_rotate = (Mathf.Atan2(delta.y, delta.x) - (33)) * Mathf.Rad2Deg;

            transform.RotateAround(FindAnyObjectByType<PlayerData>().transform.position, new Vector3(0,0,1), 1f);
            gameObject.GetComponentInChildren<Rigidbody2D>().AddForceY(Player.GetComponent<PlayerData>().moveSpeed);
            transform.rotation = Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1));
        }
    }
}
