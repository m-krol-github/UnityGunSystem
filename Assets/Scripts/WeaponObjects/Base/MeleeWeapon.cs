using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/MeleeWeapon", order = 0)]
    public class MeleeWeapon : ItemScriptableObject, IMeleeWeapons
    {
        public float strength;
        public float Strength { get { return strength; } }

        public override void PrimaryAction()
        {
            Debug.Log("Attack " + strength + " of power");
        }

        public override IEnumerator Execute()
        {
            yield return new WaitForSeconds(cooldownTime);
            Debug.Log("Attack " + strength + " of power has hit it's target!!!");
        }
    }
}