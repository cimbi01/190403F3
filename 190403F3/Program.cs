using System;
using System.Collections;

namespace _190403F3
{
    internal static class Program
    {
        #region Private Methods

        private static Stack Atvaltas(int szam, int szamrendszer)
        {
            Stack stack = new Stack();
            while (szam > 0)
            {
                int szamrendszerbeliszam = szam % szamrendszer;
                szam = (szam - szamrendszerbeliszam) / 2;
                stack.Push(szamrendszerbeliszam);
            }
            return stack;
        }

        #endregion Private Methods

        #region Private Methods

        private static void Main(string[] args)
        {
            int szam = AdatBekeres.EllenorzottBekeres("Add meg a decimális egész számot", 0);
            int szamrendszer = AdatBekeres.EllenorzottBekeres("Add meg a számrendszert", 2, 10);
            Stack stack = Atvaltas(szam, szamrendszer);
            string szamrendszerbeliszam = "";
            while (stack.Count > 0)
            {
                szamrendszerbeliszam += Convert.ToString(stack.Pop());
            }
            Console.WriteLine(szamrendszerbeliszam);
            Console.ReadKey();
        }

        #endregion Private Methods
    }
}
