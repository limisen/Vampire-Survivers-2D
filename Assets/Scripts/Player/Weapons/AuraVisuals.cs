using UnityEngine;

public class AuraVisuals : Weapons.Aura_Data
{
    void Update()
    {
        transform.localScale = new Vector3(1 + radius, 1 + radius, 1 + radius);
    }
}
