using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Defining the UpgradeTypes (Weapons or Player stats)
    public enum UpgradeType
    {
        MagicMissile,
        Aura,
        ChainLightning,
        Player
    }

    // Define which attributes/stats are possible to change
    public enum UpgradeableStats
    {
        Damage,
        MoveSpeed,
        AmountToSpawn,
        TimeBetweenSpawns,
        Radius,
        AmountToChain,
        MaxHP,
        Unlocked
    }

    public UpgradeType Type { get; set; }
    public UpgradeableStats[] AvailableStats { get; set; }

    Upgrades(UpgradeType type, params UpgradeableStats[] stats)
    {
        Type = type;
        AvailableStats = stats;
    }

    // Dependant on which type only certain attributes/stats are allowed to change
    List<Upgrades> UpgradesList;
    private void Awake()
    {
        UpgradesList = new()
        {
            // Magic Missile
            new Upgrades(
                UpgradeType.MagicMissile,
                UpgradeableStats.Damage,
                UpgradeableStats.MoveSpeed,
                UpgradeableStats.AmountToSpawn,
                UpgradeableStats.TimeBetweenSpawns,
                UpgradeableStats.Unlocked
            ),
            // Aura
            new Upgrades(
                UpgradeType.Aura,
                UpgradeableStats.Damage,
                UpgradeableStats.Radius,
                UpgradeableStats.Unlocked
            ),
            // ChainLightning
            new Upgrades(
                UpgradeType.ChainLightning,
                UpgradeableStats.Damage,
                UpgradeableStats.AmountToChain,
                UpgradeableStats.TimeBetweenSpawns,
                UpgradeableStats.Unlocked
            ),
            // PlayerStats
            new Upgrades(
                UpgradeType.Player,
                UpgradeableStats.MoveSpeed,
                UpgradeableStats.MaxHP
            )
        };
    }

    public List<Upgrades> GetRandomUpgrades(int amount)
    {
        List<Upgrades> available = new(UpgradesList);
        List<Upgrades> result = new();

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, available.Count);

            result.Add(available[randomIndex]);
            available.RemoveAt(randomIndex);
        }

        return result;
    }
}