using UnityEngine;

public class Weapons : MonoBehaviour
{
    public class MagicMissile_Data : Weapons
    {
        [SerializeField] public float DMG = 5;
        [SerializeField] public float MoveSpeed = 10;
        [SerializeField] public float amount_to_spawn = 1;
        [SerializeField] public float time_between_launch = 2;
    }

    public class ChainLightning_Data : Weapons
    {
        [SerializeField] public float DMG = 5;
        [SerializeField] public float amount_to_chain = 1;
        [SerializeField] public float time_between_lightning = 2;
    }

    public class Aura_Data : Weapons
    {
        [SerializeField] public float DMG = 5;
        [SerializeField] public float radius = 5;
    }
}