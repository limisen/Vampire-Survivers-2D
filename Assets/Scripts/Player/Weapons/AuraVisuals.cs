using UnityEngine;

public class AuraVisuals : Weapons.Aura_Data
{
    void Update()
    {
        radius = GetComponentInParent<Aura>().radius;

        radius *= 1.15f;

        transform.localScale = new Vector3(radius, radius, 0);
    }
}
