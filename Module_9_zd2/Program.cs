using System;
using System.Collections;

namespace Module_9_zd2
{

   class Program
   {

      public static void Main(string[] args)
      {

         SortingSelection sorting = new SortingSelection();
         sorting.EneteredEvent += SortintArray;
         try
         {
            sorting.Read();
         }
         catch (FormatException ex)
         {
            Console.WriteLine("Вы ввели не цифру");
         }
         catch (MyException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
      public static void SortintArray(int n)
      {
         string[] surnames = new string[] { "Павлов", "Иванов", "Петров", "Климов", "Юрченко" };
         switch (n)
         {
            case 1:
               Array.Sort(surnames);
               break;
            case 2:
               IComparer revComparer = new ReverseComparer();
               Array.Sort(surnames, revComparer);
               break;
            default:
               throw new MyException();
         }
         foreach (var words in surnames)
            Console.WriteLine(words);
      }
   }

   public class SortingSelection
   {
      public delegate void EneteredDelegate(int n);
      public event EneteredDelegate EneteredEvent;

      public void Read()
      {
         Console.WriteLine("Введите 1, чтобы сделать прямую сортировку фамилий\nВведите 2, чтобы сделать обратную сортировку фамилий");
         int n = Convert.ToInt32(Console.ReadLine());
         if (n != 1 && n != 2) throw new MyException("Вы ввели неправильное число");
         Entered(n);
      }

      protected virtual void Entered(int n)
      {
         EneteredEvent?.Invoke(n);
      }
   }

   public class MyException : Exception
   {
      public MyException()
      { }
      public MyException(string message) : base(message)
      { }
   }

   public class ReverseComparer : IComparer
   {
      public int Compare(Object x, Object y)
      {
         return (new CaseInsensitiveComparer()).Compare(y, x);
      }
   }
}
