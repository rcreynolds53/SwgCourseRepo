using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool isGreatParty = (cigars >= 40) && (cigars <= 60 || isWeekend);
            return isGreatParty;
        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int yes = 2;
            int maybe = 1;
            int no = 0;

            if (yourStyle > 7 || dateStyle > 7)
            {
                return yes;
            }
            else if (yourStyle < 3 || dateStyle < 3)
            {
                return no;
            }
            return maybe;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool isOutside = ((temp >= 60 && temp <= 90)) || ((isSummer) && (temp >= 60 && temp <= 100));
            return isOutside;
        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int NoTicket = 0;
            int SmallTicket = 1;
            int BigTicket = 2;

            if (isBirthday)
            {
                speed = speed - 5;
            }

            if ((speed >= 61 && speed <= 80))
            {
                return SmallTicket;
            }
            else if ((speed >= 81))
            {
                return BigTicket;
            }
            return NoTicket;
        }

        public int SkipSum(int a, int b)
        {
            int sum = a + b;

            if (sum >= 10 && sum <= 19)
            {
                return 20;
            }
            return sum;
        }

        public string AlarmClock(int day, bool vacation)
        {
            
            if(!vacation && (day > 0 && day< 6))
            {
                return "7:00";
            }
            return "10:00";
        }

        public bool LoveSix(int a, int b)
        {
            int sum = a + b;
            int diff = a - b;

            return (a == 6 || b == 6 || sum == 6 || diff == 6);
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            while(outsideMode)
            {
                if(n<= 1 || n >=10) 
                {
                    return true;
                }
                return false;
            }
            if(!outsideMode && (n >= 1 && n <= 10))
            {
                return true;
            }
            return false;

        }
        
        public bool SpecialEleven(int n)
        {
            bool isSpecial = (n % 11 == 0 || n % 11 == 1);
            return isSpecial;
        }
        
        public bool Mod20(int n)
        {
            bool is1or2More = (n > -1 && (n % 20 == 1 || n % 20 == 2));
            return is1or2More;
        }
        
        public bool Mod35(int n)
        {
            bool isMult3or5 = (n > -1 && (n % 3 == 0 || n % 5 == 0) && !(n % 3 == 0 && n % 5 == 0));
            return isMult3or5;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            while(!isAsleep)
            {
                if((isMom && isMorning) || !isMorning)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if(a== (b + c)|| b == (a + c) || c == (a + b))
            {
                return true;
            }
            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
