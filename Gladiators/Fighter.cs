using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Gladiators
{
    class Fighter
    {
        private enum WeaponType
        {
            Sword,
            TwoHandedSword,
            Spear,
            Axe
        };

        private enum OffhandType
        {
            Shield,
            Net,
            Dagger
        };

        Random rnd = new Random();
        private int _health;
        private WeaponType _weapon;
        private OffhandType _offhand;

        // static constructor - random fighter
        public Fighter()
        {
            // set health
            SetHealth(100);

            // set weapon
            SetWeapon(RandomEnumValue<WeaponType>());

            // set offhand
            SetOffhand(RandomEnumValue<OffhandType>());
        }

        // constructor
        public Fighter(string userWep, string userOff)
        {
            // set health
            SetHealth(100);

            // set weapon
            SetWeapon(userWep);

            // set offhand
            SetOffhand(userOff);
        }

        // attempts to assign weapon, returns true on success
        private bool SetWeapon(string weaponName)
        {
            foreach (var weapon in Enum.GetValues(typeof(WeaponType)))
            {
                if (weapon.ToString() == weaponName)
                {
                    _weapon = Enum.Parse<WeaponType>(weapon.ToString());
                    return true;
                }
            }
            return false;
        }

        private bool SetWeapon(WeaponType weapon)
        {
            _weapon = weapon;
            return true;
        }

        // attempts to assign offhand, returns true on success
        private bool SetOffhand(string offhandName)
        {
            foreach (var offhand in Enum.GetValues(typeof(OffhandType)))
            {
                if (offhand.ToString() == offhandName)
                {
                    _offhand = Enum.Parse<OffhandType>(offhand.ToString());
                    return true;
                }
            }
            return false;
        }

        private bool SetOffhand(OffhandType offhand)
        {
            _offhand = offhand;
            return true;
        }

        // get random enum value
        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(new Random().Next(v.Length));
        }

        private void SetHealth(int health)
        {
            _health = health;
        }

        // get damage roll from fighter
        public int GetDamage()
        {
            switch (_weapon)
            {
                case WeaponType.Sword:
                    return rnd.Next(2, 6);
                case WeaponType.Axe:
                    return rnd.Next(0, 10);
                case WeaponType.Spear:
                    return rnd.Next(3, 7);
                case WeaponType.TwoHandedSword:
                    return rnd.Next(0, 10);
            }

            return 0;
        }

        // register damage
        public void SetDamage(int damage)
        {
            _health -= damage;
        }

        // get hp
        public int getHealth()
        {
            return _health;
        }

        // get equips seperated by " and "
        public string GetEquips()
        {
            return _weapon.ToString() + " and " +_offhand.ToString();
        }

        // return string of weapons seperated by '\n'
        public static string GetWeaponList()
        {
            string list = "";
            foreach(string weapon in Enum.GetNames(typeof(WeaponType)))
            {
                list += weapon + "\n";
            }
            return list;
        }

        // return string of offhands seperated by '\n'
        public static string GetOffhandList()
        {
            string list = "";
            foreach (string weapon in Enum.GetNames(typeof(OffhandType)))
            {
                list += weapon + "\n";
            }
            return list;
        }
    }
}
