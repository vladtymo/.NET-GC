using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_dispose
{
    class HardClass : IDisposable
    {
        int[] array = null;
        bool isConnected = false;
        private bool disposedValue;

        public HardClass()
        {
            Connect();
            array = new int[1000];
        }
        public void Connect()
        {
            isConnected = true;
            Console.WriteLine("Connected!");
        }
        public void Disconnect()
        {
            isConnected = false;
            Console.WriteLine("Disconnected!");
        }
        public void BadOperation()
        {
            throw new Exception("Error!");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Disconnect();
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~HardClass()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static void TestHardWork()
        {
            //HardClass hard = new HardClass();
            //try
            //{
            //    // ... working with object ...
            //    hard.BadOperation();
            //}
            //finally
            //{
            //    // clear unmanagement resources
            //    hard.Disconnect();
            //}

            //................ the same
            using (HardClass hard = new HardClass()) // create an instance of IDisposable class
            {
                // ... working with object ...
                hard.BadOperation();

            } // invoke Dispose() method
        }
        static void Main(string[] args)
        {
            TestHardWork();

            GC.Collect();
            Console.ReadKey();
        }
    }
}
