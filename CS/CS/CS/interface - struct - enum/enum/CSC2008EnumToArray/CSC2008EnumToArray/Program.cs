using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSC2008EnumToArray
{
    public static class Utils
    {
        public static T[] EnumToArray<T>()
        {
            Type enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be a System.Enum");
            }
            return (Enum.GetValues(enumType) as IEnumerable<T>).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Convert Enum type to an array
            RoleType[] allRoles = Utils.EnumToArray<RoleType>();

            //Use IEnumerable.Except to get part of the array
            RoleType[] localUserRoles = new RoleType[] { RoleType.LocalAdmin, RoleType.LocalUser, RoleType.Guest };

            RoleType[] domainUserRoles = allRoles.Except(localUserRoles).ToArray();

            for (int Index = 0; Index < domainUserRoles.Length; Index++)
            {
                Console.WriteLine(domainUserRoles[Index]);
            }

            Console.ReadKey();
        }

        enum RoleType
        {
            DomainAdmin,
            LocalAdmin,
            DomainUser,
            LocalUser,
            Guest
        }
    }
}
