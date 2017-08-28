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
            string Every2 = "";

            for (int i = 0; i < str.Length; i += 2)
            {
                Every2 += str.Substring(i,1);
            }
            return Every2;
        }
        public string StringSplosion(string str)
        {
            string AddStrings = "";

            for (int i = 0; i < str.Length; i++)
            {
                AddStrings += str.Substring(0, i+1);
            }
            return AddStrings;
        }

        public int CountLast2(string str)
        {
            string LastTwo = str.Substring(str.Length - 2, 2);
            int CountTwo = -1;

            for (int i = 0; i < str.Length-1; i++)
            {
                if (str.Substring(i,2) == LastTwo) 
                {
                    CountTwo++;
                }
            }
            return CountTwo;
        }

        public int Count9(int[] numbers)
        {
            int Count9s = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    Count9s++;
                }
            }
            return Count9s;
        }

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        } 

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int CountStrings = 0;
            if (a.Length > b.Length)
            {
                for (int i = 0; i < b.Length - 1; i++)
                {
                    if (a.Substring(i, 2) == b.Substring(i, 2))
                    {
                        CountStrings++;
                    }
                }
                return CountStrings;
            }
            else
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a.Substring(i, 2) == b.Substring(i, 2))
                    {
                        CountStrings++;
                    }
                }
                return CountStrings;
            }
        }

        public string StringX(string str)
        {
            string Front = str.Substring(0, 1);
            string Back = str.Substring(str.Length - 1, 1);
            string NoX = "";
            for (int i = 1; i < str.Length-1; i++)
            {
                if (str.Substring(i, 1) != "x")
                {
                    NoX += str.Substring(i, 1);
                }
            }
            return Front +NoX + Back;                 
        }

        public string AltPairs(string str)
        {
            string EveryTwo = "";
            string Last = str.Substring(str.Length - 1, 1);

            for (int i = 0; i < str.Length-1; i+=4)
            {
                EveryTwo += str.Substring(i, 2);
            }
            if(str.Length % 2 ==1)
            {
                return EveryTwo + Last;
            }
            return EveryTwo;
        }

        public string DoNotYak(string str)
        {
            for (int i = 0; i < str.Length-2; i++)
            {
                if(str.Substring(i,3) == "yak")
                {
                    str = str.Remove(i, 3);
                }
            }
            return str;
        }

        public int Array667(int[] numbers)
        {
            int Count6s = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                {
                    Count6s++;
                }
            }
             return Count6s;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-2; i++)
            {
                int Current = numbers[i];
                int Next = numbers[i + 1];
                int TwoAway = numbers[i + 2];

                if (Current == Next && Next == TwoAway)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i + 1] == numbers[i] + 5 && numbers[i + 2] == numbers[i] - 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
