using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Weapons
{
    public class Player : MonoBehaviour, IWeapon
    {
        [SerializeField] private AllWeaponsObject weapons;
        [SerializeField] private CurrentWeapon currentWeapon;
        [SerializeField] private TextMeshProUGUI weaponText;

        private ItemScriptableObject activeWeapon;
        private int weaponIndex = 0;

        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();

            _controls.Shoot.Mouse.canceled += _ => PrimaryAction();
            _controls.ChangeWeapon.Mouse.performed += _ => SecondaryAction();

            if (activeWeapon == null)
            {
                activeWeapon = weapons.avaibleWeapons[weaponIndex];
                currentWeapon.current = activeWeapon;
                weaponText.text = activeWeapon.weaponName;
            }
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        public void PrimaryAction()
        {
            activeWeapon.PrimaryAction();
            currentWeapon.Run();
        }

        public void SecondaryAction()
        {
            weaponIndex++;

            if (weapons.avaibleWeapons.Count == weaponIndex)
                weaponIndex = 0;

            activeWeapon = weapons.avaibleWeapons[weaponIndex];
            weaponText.text = activeWeapon.weaponName;
            currentWeapon.current = activeWeapon;
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}