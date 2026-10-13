using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    GameObject Player;
    public float ProjectileMoveSpeed;

    [SerializeField] float maxTimeAlive;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            maxTimeAlive -= Time.deltaTime;

            // calculate(ed) the direction between this object and the target object
            Vector3 delta = Player.transform.position - transform.position;

            // make sure not to move closer on the Z-Axis
            delta.z = 0;

            // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
            delta.Normalize();

            // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
            float angle_to_rotate = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            // Now set the position and then rotate so we are facing the target (aka the player)
            transform.SetPositionAndRotation((transform.position += (Time.deltaTime * ProjectileMoveSpeed) * delta), Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1)));

            if (maxTimeAlive <= 0) { Destroy(this.gameObject); }
        }
    }
}
