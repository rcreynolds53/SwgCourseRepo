using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool isFirstorLast = (numbers[0] == 6 || numbers[numbers.Length - 1] == 6);
            return isFirstorLast;
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool isSame = (numbers[0] == numbers[numbers.Length - 1]);
            return isSame;
        }
        public int[] MakePi(int n)
        {
            var pi = Math.PI;
            string str = pi.ToString().Remove(1, 1);
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(str[i].ToString());
            }
            return numbers;

        }
        public bool CommonEnd(int[] a, int[] b)
        {
            bool hasCommonEnd = (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]);
            return hasCommonEnd;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int ray = numbers.Length;
            int[] RotateNumbers= new int[ray];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    RotateNumbers[i] = numbers[0];
                }
                else
                {
                    RotateNumbers[i] = numbers[i + 1];
                }
            }
            return RotateNumbers;

        }
        
        public int[] Reverse(int[] numbers)
        {
			int ray = numbers.Length;
			int[] ReverseNumbers = new int[ray];

			for (int i = numbers.Length - 1; i >= 0; i--)
			{
				ReverseNumbers[i] = numbers[(numbers.Length - 1) - i];
			}
			return ReverseNumbers;
        }

        public int[] HigherWins(int[] numbers)
        {
            int n = numbers.Length;
            int[] HigherNumbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] > numbers[numbers.Length - 1])
                {
                    HigherNumbers[i] = numbers[0];
                }
                else
                {
                    HigherNumbers[i] = numbers[numbers.Length - 1];
                }
            }
            return HigherNumbers;
        }
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] MiddleAandB = { a[1], b[1] };
            return MiddleAandB;
        }
        
        public bool HasEven(int[] numbers)
        {
			/*foreach (var item in numbers) 
            {
                if(item % 2 ==0)
                {
                    return true;
                }
            }
            return false;*/

		for (int i = 0; i < numbers.Length; i++)
		{
			if(numbers[i] % 2 == 0)
			{
				return true;
			}
		}
		return false; 
	    }

        public int[] KeepLast(int[] numbers)
        {
            int[] LastNumber = new int[numbers.Length * 2];

            for (int i = 0; i < numbers.Length; i++)
            {
                LastNumber[LastNumber.Length - 1] = numbers[numbers.Length - 1];
            }
            return LastNumber;

        }
		public bool Double23(int[] numbers)
        {
            int ArrayofTwos = 0;
            int ArrayofThrees = 0;

            foreach(var item in numbers)
            {
                if(item == 2)
                {
                    ArrayofTwos++;
                }
                else if(item == 3)
                {
                    ArrayofThrees++;
                }
            }
            if(ArrayofTwos == 2 || ArrayofThrees == 2)
            {
                return true;
            }
            return false;
        }

        public int[] Fix23(int[] numbers)
        {
            int n = numbers.Length;
            int[] NumbershasThree = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                NumbershasThree[i] = numbers[i];

                if (numbers[i] == 3 && numbers[i-1] == 2)
                {
                    numbers[i] = 0;
                    NumbershasThree[i] = numbers[i];
                }
            }

            return NumbershasThree;
        }
        public bool Unlucky1(int[] numbers)
        {
            bool isUnlucky = ((numbers[0] == 1 && numbers[1] == 3) || (numbers[1] == 1 && numbers[2] == 3) || (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3));
            return isUnlucky;                                                                                                       
        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] Made2 = new int[2];


            if(a.Length == 1 && b.Length > 0)
            {
                Made2[0] = a[0];
                Made2[1] = b[0];
            }
            else if(a.Length == 0 && b.Length > 1)
            {
                Made2[0] = b[0];
                Made2[1] = b[1];
            }
            else
            {
				Made2[0] = a[0];
				Made2[1] = a[1];
            }

            return Made2;
        }

    }
}
