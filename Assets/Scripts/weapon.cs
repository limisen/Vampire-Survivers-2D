using UnityEngine;

public class weapon : MonoBehaviour
{

    public float dmg = 1;


    public class Aura : weapon
    {
        // deal dmg here
    }

    public class MagicMissile : weapon
    {
        [SerializeField] int missiles_to_fire = 1;

        [SerializeField] GameObject missle_Prefab;
        private void Update()
        {
            for (int i = 0; i < missiles_to_fire; i++)
            {
                Instantiate(missle_Prefab);
            }
            // deal dmg here
        }

        
    }

    public class ChainLightning : weapon
    {
        [SerializeField] int missiles_to_fire = 1;
        // deal dmg here
    }
}
