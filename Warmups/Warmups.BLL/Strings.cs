using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
             string Tagged = string.Format("<{0}>{1}</{0}>", tag, content);
            return Tagged;

        }

        public string InsertWord(string container, string word) {
            string Front = container.Substring(0, 2);
            string End = container.Substring(2, 2);
            return Front + word + End;
        }

        public string MultipleEndings(string str)
        {
            string Endings = str.Substring(str.Length - 2, 2);
            return Endings + Endings + Endings;
        }

        public string FirstHalf(string str)
        {
            string Front = str.Substring(0, str.Length / 2);
            return Front;
        }

        public string TrimOne(string str)
        {
            string Trimmed = str.Substring(1, str.Length - 2);
            return Trimmed;
        }

        public string LongInMiddle(string a, string b)
        {
            if(a.Length > b.Length)
            {
                return b + a + b;
            }
            return a + b + a;
        }

        public string RotateLeft2(string str)
        {
            string FrontTwo = "";
            string BackPart = str.Substring(2, str.Length - 2);
            if(str.Length >= 3)
            {
                FrontTwo = str.Substring(0, 2);
                return BackPart + FrontTwo; 
            }
            return str;
        }

        public string RotateRight2(string str)
        {
            string LastTwo = str.Substring(str.Length -2,2);
            string Front = str.Substring(0, str.Length-2);
            if(str.Length >= 3)
            {
                return LastTwo + Front;
            }
            return str;
        }

        public string TakeOne(string str, bool fromFront)
        {
            string FrontorBack1 = str.Substring(0, 1); 
            if (!fromFront)
            {
                FrontorBack1 = str.Substring(str.Length - 1, 1);
                return FrontorBack1;
            }

            return FrontorBack1;
        }

        public string MiddleTwo(string str)
        {
            string Middle = str.Substring((str.Length / 2) - 1, 2);
            return Middle;
        }

        public bool EndsWithLy(string str)
        {
            if(str.Length < 2 || str.Substring(str.Length-2,2) != "ly")
            {
                return false;
            }
            return true;
        }

        public string FrontAndBack(string str, int n)
        {
            string FrontN = str.Substring(0, n);
            string BackN = str.Substring(str.Length - n, n);
            return FrontN + BackN;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n == 0 || n > str.Length || (str.Length - n) < 2 )
            {
                return str.Substring(0, 2);
            }
            return str.Substring(n, 2);
        }


        public bool HasBad(string str)
        {
            if(str.Length < 1)
            {
                return false;
            }
            else if(str.Substring(0,3) == "bad" || str.Substring(1,3) == "bad")
            {
                return true;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length < 1)
            {
                return "@@";
            }
            else if (str.Length > 1)
            {
                return str.Substring(0, 2);
            }
            string first = str.Substring(0, 1);
			return first + "@";
        }

        public string LastChars(string a, string b)
        {
            string FirstCharA = "";
            string LastCharB = "";

            if (a.Length < 1 && b.Length < 1)
            {
                return "@@";
            }
            else if (a.Length < 1 && b.Length > 0)
            {
                LastCharB = b.Substring(b.Length - 1, 1);
                return "@" + LastCharB;
            }
            else if (a.Length > 0 && b.Length < 1)
            {
                FirstCharA = a.Substring(0, 1);
                return FirstCharA + "@";
            }

            FirstCharA = a.Substring(0, 1);
            LastCharB = b.Substring(b.Length - 1, 1);
            return FirstCharA + LastCharB;
        }

        public string ConCat(string a, string b)
        {
            string NewA = "";
            string NewB = "";
            if(a.Length == 0 || b.Length == 0)
            {
                return a + b;
            }
            else if(a.Substring(a.Length-1,1) == b.Substring(0,1))
            {
                NewA = a.Substring(0, a.Length);
                NewB = b.Substring(1, b.Length-1);
                return NewA + NewB;
            }
            return a + b;
                
        }

        public string SwapLast(string str)
        {
            string Start = "";
            string SecondtoLast = "";
            string Last = "";
            if( str.Length < 2)
            {
                return str;
            }
            else if(str.Length < 3)
            {
			 Start = str.Substring(0, str.Length - 2);
			 SecondtoLast = str.Substring(str.Length - 2, 1);
			 Last = str.Substring(str.Length - 1, 1);
             return Last + SecondtoLast;
            }
			Start = str.Substring(0, str.Length - 2);
			SecondtoLast = str.Substring(str.Length - 2, 1);
			Last = str.Substring(str.Length - 1, 1);
            return Start + Last + SecondtoLast;
        }

        public bool FrontAgain(string str)
        {
            if (str.Length < 3)
            {
                return true;
            }
            else if(str.Substring(0,2)== str.Substring(str.Length-2,2))
            {
                return true;
            }
            return false;
        }

        public string MinCat(string a, string b)
        {
            string NewA = "";
            string NewB = "";

            if(a.Length > b.Length)
            {
                NewA = a.Substring(a.Length - b.Length, b.Length);
                return NewA + b;
            }
            else if(a.Length < b.Length)
            {
                NewB = b.Substring(b.Length - a.Length, a.Length);
                return a + NewB;
            }
            return a + b;
        } 

        public string TweakFront(string str)
        {
       		string NewStrA = "";
            string NewStrB = "";

            if (str.Length < 1)
            {
                return str;
            }
            else if (str.Substring(0, 1) != "a" && str.Substring(1, 1) == "b")
            {
                NewStrA = str.Substring(1, str.Length - 1);
                return NewStrA;

            }
            else if (str.Substring(0, 1) == "a" && str.Substring(1, 1) != "b")
            {
                NewStrA = str.Substring(0, 1);
                NewStrB = str.Substring(2, str.Length - 2);
                return NewStrA + NewStrB;
            }
            else if (str.Substring(0, 2) != "ab")
            {
                NewStrA = str.Substring(2, str.Length - 2);
                return NewStrA;
            }
            return str;
		}

        public string StripX(string str)
        {
            string Front = "";
            string Back = "";

            if (str.Length < 2)
            {
                return Front;
            }
            else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) != "x")
            {
                Front = str.Substring(1, str.Length - 1);
                return Front;
            }
            else if (str.Substring(0, 1) != "x" && str.Substring(str.Length - 1, 1) == "x")
            {
                Back = str.Substring(0, str.Length - 1);
                return Back;
            }
			else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) == "x")
            {
                Back = str.Substring(1, str.Length - 2);
                return Back;
            }
                

				return str;
        }
    }
}
