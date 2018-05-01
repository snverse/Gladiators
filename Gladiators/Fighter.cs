using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Text;

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

        private uint _health;
        private WeaponType _weapon;
        private OffhandType _offhand;

        // constructor
        private Fighter(string userWep, string userOff)
        {
            // set health
            _health = 100;

            // set weapon
            try
            {
                _weapon = Enum.TryParse(userWep, out WeaponType, _weapon);
            }
            catch (Exception e)
            {
                _weapon = WeaponType.Sword;
            }
            
            // set offhand
            try
            {
                _offhand = OffhandType.;
            }
            catch (Exception e)
            {
                _offhand = OffhandType.Shield;
            }
        }

        public static SetDamage(uint damage)
        {

        }

        public static string GetWeaponList()
        {
            string list = "";
            foreach(string weapon in Enum.GetNames(typeof(WeaponType)))
            {
                list += weapon + "\n";
            }
            return list;
        }

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
