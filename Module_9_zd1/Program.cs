using System;

namespace Module_9_zd1
{
   class Program
   {
      static void Main(string[] args)
      {
         Exception[] exceptions = new Exception[] { new DivideByZeroException(), new ArgumentNullException(), new NotImplementedException(), new NotSupportedException(), new MyException("Моё исключение") };
         try
         {
            Console.WriteLine("1 - вызвать исключение DivideByZeroException\n2 - вызвать исключение ArgumentNullException\n3 - вызвать исключение NotImplementedException\n4 - вызвать исключение NotSupportedException\n5 - вызвать исключение MyException");
            string n = Console.ReadLine();
            switch (n)
            {
               case "1":
                  throw new DivideByZeroException();
               case "2":
                  throw new ArgumentNullException();
               case "3":
                  throw new NotImplementedException();
               case "4":
                  throw new NotSupportedException();
               case "5":
                  throw new MyException();
               default:
                  Console.WriteLine("Исключения не вызваны");
                  break;
            }
         }
         catch (DivideByZeroException)
         {
            Console.WriteLine(exceptions[0].Message);
         }
         catch (ArgumentNullException)
         {
            Console.WriteLine(exceptions[1].Message);
         }
         catch (NotImplementedException)
         {
            Console.WriteLine(exceptions[2].Message);
         }
         catch (NotSupportedException)
         {
            Console.WriteLine(exceptions[3].Message);
         }
         catch (MyException)
         {
            Console.WriteLine(exceptions[4].Message);
         }
      }
   }

   public class MyException : Exception
   {
      public MyException()
      { }
      public MyException(string message) : base(message)
      { }
   }
}
