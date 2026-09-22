using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    // How fast to move towards enemies
    [SerializeField] float moveSpeed;
    public float rotation_Speed;

    // FindNearest() releavent variables
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject nearestObj;
    float Enemy_distance;
    float nearestDistance = float.PositiveInfinity;

    // Orbiting relavent distances
    public float distance_from_Player = 1;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // Look for enemies
        FindNearest();
    }

    void LateUpdate()
    {
        if (GameManager.singleton.gamePaused == false && nearestObj != null)
        {
            // calculate(ed) distance between this object and the target object
            Vector3 delta = nearestObj.transform.position - transform.position;

            // make sure not to move closer on the Z-Axis
            delta.z = 0;

            // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
            delta.Normalize();

            // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
            float angle_to_rotate = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            // Now set the position and then rotate so we are facing the target (aka the player)
            transform.SetPositionAndRotation((transform.position += (Time.deltaTime * moveSpeed) * delta), Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1)));
        }

        else if (GameManager.singleton.gamePaused == false)
        {
            Oribit_movement();
        }
    }

    public void FindNearest()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemy_distance = Vector3.Distance(this.transform.position, Enemies[i].transform.position);

            if (Enemy_distance < nearestDistance)
            {
                nearestObj = Enemies[i];
                nearestDistance = Enemy_distance;
            }
        }
        nearestDistance = float.PositiveInfinity;
    }

    void Oribit_movement()
    {
        // calculate(ed) the delta distance between this object and the target object
        Vector3 delta = Player.transform.position - transform.position;

        // make sure not to move closer on the Z-Axis
        delta.z = 0;

        // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
        delta.Normalize();

        distance_from_Player = Vector3.Distance(Player.transform.position, transform.position);

        // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
        float angle_to_rotate = (Mathf.Atan2(delta.y, delta.x) - (33)) * Mathf.Rad2Deg;

        // Move into the defined max- and minimum-range 
        if (distance_from_Player > maxDistance)
        {
            transform.position += Time.deltaTime * moveSpeed * delta;
        }

        if (distance_from_Player < minDistance)
        {
            transform.position -= Time.deltaTime * moveSpeed * delta;
        }

        // get the rotation speed based on the normal moveSpeed towards enemies. Convert to Degrees and scale it to be Per Second
        rotation_Speed = Mathf.Atan(moveSpeed) * Mathf.Rad2Deg * Time.deltaTime;

        // Last argument (rotation_Speed) is the amount in degrees to rotate
        transform.RotateAround(Player.transform.position, new Vector3(0, 0, 1), rotation_Speed);

        // Apply the rotation to face the direction the missile is moving in
        transform.rotation = Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1));
    }
}
