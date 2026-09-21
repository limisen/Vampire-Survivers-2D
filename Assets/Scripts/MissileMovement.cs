using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public List<GameObject> Enemies = new List<GameObject>();

    public GameObject nearestObj;
    float Enemy_distance;
    float nearestDistance = float.PositiveInfinity;

    public float distance_from_Player;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        FindNearest();
    }

    private void Update()
    {
        FindNearest();
    }

    void LateUpdate()
    {
        if (nearestObj == null)
        {
            FindNearest();
        }

        //if (nearestObj == null)
        //{
        //    nearestObj = Enemies[0];
        //}

        if (GameManager.singleton.gamePaused == false && Enemies.Count > 0 && nearestObj != null)
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


        if (distance_from_Player > maxDistance)
        {
            transform.position += Time.deltaTime * moveSpeed * delta;
        }

        if (distance_from_Player < minDistance)
        {
            transform.position -= Time.deltaTime * moveSpeed * delta;
        }

        transform.RotateAround(FindAnyObjectByType<PlayerData>().transform.position, new Vector3(0, 0, 1), 1f);
        gameObject.GetComponentInChildren<Rigidbody2D>().AddForceY(Player.GetComponent<PlayerData>().moveSpeed);
        transform.rotation = Quaternion.AngleAxis(angle_to_rotate, new Vector3(0, 0, 1));
    }
}
