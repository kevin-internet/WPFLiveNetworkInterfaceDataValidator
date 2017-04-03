using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 public sealed class Singleton
{
   private static readonly Singleton instance = new Singleton();
   
   private Singleton(){}

   public static Singleton Instance
   {
      get 
      {
         return instance; 
      }
   }
}
     */

namespace NodeManagerUI
{
    public static class MaximumThresholdValues
    {
        private static long _maxBytesSent;


        public static long MaxBytesSent
        {
            get { return _maxBytesSent; }
            set
            {
                _maxBytesSent = value;
            }
        }

        private static long _maxBytesReceived;
        public static long MaxBytesReceived
        {
            get { return _maxBytesReceived; }
            set
            {
                _maxBytesReceived = value;
            }
        }
    }
}
