using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string str2 = "";
            for (int i = 0; i < n; i++)
            {
                str2 += str;
            }
            return str2;
        }

        public string FrontTimes(string str, int n)
        {
            string AddFront = "";

            for (int i = 0; i < n; i++)
            {
                AddFront += str.Substring(0,3);
            }
            return AddFront;
        }

        public int CountXX(string str)
        {
            int CountX = -1;

            for (int i = 0; i < str.Length; i++)
            {
                if(str.Substring(i,1) == "x")
                {
                    CountX++;
                }
            }
            return CountX;
        }

        public bool DoubleX(string str)
        {
            string XX = "";
            int i = 0;

            while (i < str.Length-1 && str.Substring(i, 1) != "x")
            {
                i++;
            }
            if(i == str.Length-1)
            {
                return false;
            }
			XX = str.Substring(i, 2);

            return (XX == "xx");
        }

        public string EveryOther(string str)
        {
            /*
            string Others = "";
            for (int i = 0; i < str.Length; i+2) 
            {
                Others = str.Remove(i);
            }
            return Others;
        }*/

        public string StringSplosion(string str)
        {
            throw new NotImplementedException();
        }

        public int CountLast2(string str)
        {
            throw new NotImplementedException();
        }

        public int Count9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}
