using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
			bool inTrouble = (aSmile && bSmile) || (!aSmile && !bSmile);

			return inTrouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
			bool sleepIn = (!isWeekday || isVacation);
			return sleepIn;
        }

        public int SumDouble(int a, int b)
        {
			if (a == b) 
             {
				return 2 * (a + b);
			 }
            else
             {
				return a + b;
			 }
        }

        public int Diff21(int n)
        {
            if (n <= 21)
            {
                return 21 - n;
            }
            else
            {
                return Math.Abs(21 - n) * 2;
            }
        }
        public bool ParrotTrouble(bool isTalking, int hour)
        {
			bool inTrouble = (isTalking) && (hour > 20 || hour < 7);

			return inTrouble;
        }
        
        public bool Makes10(int a, int b)
        {
            bool Made10 = (a == 10 || b == 10) || (a + b == 10);
			return Made10;
        }
        
        public bool NearHundred(int n)
        {
			bool isNearHundred = (Math.Abs(100 - n) <= 10) || (Math.Abs(200 - n) <= 10);
			return isNearHundred;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool isNeg = ((a < 0 || b < 0) && !negative) || (negative);
            return isNeg;
        }

        public string NotString(string s)
        {
            if (s.Length < 3 || s.Substring(0, 2) != "not")
            {
                return "not " + s;
            }
            else
            {
                return s;
            }
        }

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }
        public string FrontBack(string str)
        {
			char start = str[0];
			char last = str[str.Length - 1];
			string middle = "";

            if (str.Length < 2)
            {
                return str;
            }
            else if(str.Length > 2)
            {
                middle = str.Substring(1, (str.Length - 2));
                 
            }

            return last + middle + start;
        } 
        public string Front3(string str)
        {
            string front = "";

                if(str.Length < 3)
            {
                return str + str + str;
            }
            else
            {
                front = str.Substring(0, 3);
                return front + front + front;
            }
        }
        
        public string BackAround(string str)
        {
            char last = str[(str.Length - 1)];

            return last + str + last;
        }
        
        public bool Multiple3or5(int number)
        {
            bool isMultiple3or5 = (number % 3 == 0 || number % 5 == 0);
            return isMultiple3or5;
        }

        public bool StartHi(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            else if (str.Length < 3 && str.Substring(0, 2) == "hi")
            {
                return true;
            }
            else if (str.Substring(0, 3) == "hi " || !char.IsLetter(str[2]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IcyHot(int temp1, int temp2)
        {
            bool isHot = (temp1 > 100 && temp2 < 1 || temp1 < 1 && temp2 > 100);

            return isHot;
        }
        
        public bool Between10and20(int a, int b)
        {
			bool isBetween10and20 = ((a >= 10 && a <= 20) || (b >= 10 && b <= 20));
			return isBetween10and20;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool isTeen = ((a >= 13 && a <=19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19));
            return isTeen;
        }
        
        public bool SoAlone(int a, int b)
        {
            bool isTeenAlone = (((a >= 13 && a <= 19) && (b < 13 || b > 19)) || ((a < 13 || a > 19) && (b >= 13 && b <= 19)));
            return isTeenAlone;
                
        }
        
        public string RemoveDel(string str)
        {
            if (str.Substring(1, 3) == "del") 
            {
                string r = str.Remove(1,3);
                return r;
            }
            else
            {
                return str;
            }
        }
        
        public bool IxStart(string str)
        {
            bool isIxStart = (str.Length > 2 && str.Substring(1, 2) == "ix");
            return isIxStart;
        }
        
        public string StartOz(string str)
        {
            string start = "";

            if (str.Substring(0, 1) != "o" && str.Length < 2)
            {
                return start;
            }
            else if (str.Substring(0, 2) == "oz")
            {
                start = str.Substring(0, 2);
                return start;
            }
            else if (str.Substring(0,1) == "o" && str.Substring(1, 1) != "z")
            {
                start = str.Substring(0,1);
                return start;
            }
            else if (str.Substring(1,1) == "z" && str.Substring(0,1) != "o")
            {
                start = str.Substring(1, 1);
                return start;
            }
            return start;
        }
        
        public int Max(int a, int b, int c)
        {


            if (a > b && a > c)
            {
                return a;
            }
            else if( b > a && b > c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
        
        public int Closer(int a, int b)
        {
            if (Math.Abs(10 - a) > Math.Abs(10 - b))
            {
                return b;
            }
            else if (Math.Abs(10 - a) < Math.Abs(10 - b))
            {
                return a;
            }
            return 0;
        }


        public bool GotE(string str)
        {
            int CountE = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == "e")
                {
                    CountE++;
                }
            }
            return (CountE >= 1 && CountE <= 3);
        }

        
        public string EndUp(string str)
        {
            if (str.Length < 3)
            {
                return str.ToUpper();
            }
            string Caps = str.Substring((str.Length - 3), 3);
            string Lower = str.Substring(0,(str.Length -3));
            return Lower + Caps.ToUpper();

        }
        
        public string EveryNth(string str, int n)
        {
            string EveryN = "";

            for (int i = 0; i < str.Length; i+=n)
            {
                EveryN += str.Substring(i, 1);
            }
            return EveryN;
        }
    }
}
