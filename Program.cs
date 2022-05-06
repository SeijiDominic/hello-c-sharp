// See https://aka.ms/new-console-template for more information

using System;

namespace PersonalInfoProcessor {
  class Program
  {
    static void Main(string[] args) 
    {
      Console.Write("Write your date of birth (MM-DD-YYYY): ");
      ProcessAge(Console.ReadLine());
    }

    /**
    * Display a string that tells you how old you are.
    * Returns 0 if successful, 1 if not.
    * 
    * string dob = string in MM-DD-YYYY format.
    * returns int = status
    */
    static int ProcessAge(string dob) 
    {
      try
      {
        DateOnly bd = DateOnly.Parse(dob);
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        
        Console.WriteLine("You are born on " + bd);
        
        int dayDiff = today.Day - bd.Day;
        int monthDiff = today.Month - bd.Month;
        int yearDiff = today.Year - bd.Year;
      
        if (dayDiff < 0) 
        {
          monthDiff--;
          dayDiff = GetMonthMaxDays(today.Year, MonthMutator(today.Month, -1)) + dayDiff;        
        }

        if (monthDiff < 0) 
        {
          yearDiff--;
          monthDiff = 12 + monthDiff;
        }

        if (yearDiff < 0) 
        {
          Console.WriteLine("You are not born yet, step time traveler :\')");
        }
        else 
        {
        
          Console.WriteLine("You are " + yearDiff + " years, " + monthDiff + " months, and " + dayDiff + " days old.");
        }
        return 0;
      } 
      catch(FormatException e) 
      {
        Console.WriteLine("Please Enter Valid Date.");
        return 1;
      }
    }

    /**
    * Abstracts the addition/subtraction process of months.
    * Does not calculate years added/subtracted.
    */
    static int MonthMutator (int month, int rhs)  
    {
      // In the future, check if month invalid. 
      rhs = rhs % 12;
      if (month == 1 && rhs < 0) 
      {
        return 13 + rhs;
      }
      
      if (month == 12 && rhs > 0) 
      {
        return 0 + rhs;
      }

      return month + rhs;
    }

    /**
    * Return number of days in that particular year and month.
    */
    static int GetMonthMaxDays(int year, int month)
    {
      // Local function babyyyy.
      int dayNumEval(int month) 
      {
        if (month % 2 == 0)
        {
          return 30;
        }
        else 
        {
          return 31;
        }
      }
      
      if (month == 2) 
      {
        if (year % 4 == 0) 
        {
          return 29;
        } 
        else 
        {
          return 28;
        }
      }

      if (month >= 8) 
      {
        return dayNumEval(month - 1);
      }
      else 
      {
        return dayNumEval(month);
      }
    }

  }

}





















































