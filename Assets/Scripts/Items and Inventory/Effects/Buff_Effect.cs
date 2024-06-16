using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsType
{
    strength, 
    agility, 
    intelligence,
    vitality,
    damage,
    critChance,
    critPower,
    health,
    armor,
    evasion,
    magicRes,
    fireDamage,
    iceDamage,
    ligntningDamage,
}

[CreateAssetMenu(fileName = "Buff effect", menuName = "Data/Item Effect/Buff Effect")]
public class Buff_Effect : ItemEffect
{
    private PlayerStats stats;
    [SerializeField] private StatsType buffType;
    [SerializeField] private int buffAmount;
    [SerializeField] private int buffDuration;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        stats.IncreaseStatBy(buffAmount, buffDuration, StatToModify());
    }

    private Stat StatToModify()
    {
        if (buffType == StatsType.strength) return stats.strength;
        else if (buffType == StatsType.agility) return stats.agility;
        else if (buffType == StatsType.intelligence) return stats.intelligence;
        else if (buffType == StatsType.vitality) return stats.vitality;
        else if (buffType == StatsType.damage) return stats.damage;
        else if (buffType == StatsType.critChance) return stats.critChance;
        else if (buffType == StatsType.critPower) return stats.critPower;
        else if (buffType == StatsType.health) return stats.maxHealth;
        else if (buffType == StatsType.armor) return stats.armor;
        else if (buffType == StatsType.evasion) return stats.evasion;
        else if (buffType == StatsType.magicRes) return stats.magicResistance;
        else if (buffType == StatsType.fireDamage) return stats.fireDamage;
        else if (buffType == StatsType.iceDamage) return stats.iceDamage;
        else if (buffType == StatsType.ligntningDamage) return stats.lightningDamage;

        return null;
    }
}
