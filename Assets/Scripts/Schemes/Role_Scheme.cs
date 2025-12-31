using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role_Scheme : MonoBehaviour
{
    public const int roleID = 0;
    public string roleName;
    public float baseHealth;
    public float baseMana;
    public float baseAttack;
    public float baseDefense;
    public AnimationCurve healthGrowth;
    public AnimationCurve manaGrowth;
    public AnimationCurve attackGrowth;
    public AnimationCurve defenseGrowth;
    //public List<Skill_Scheme> startingSkills;
    public List<string> allowedEquipmentTags;

}
