using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_08
{
    public class TaskAndExceptions
    {
        public async Task Run()
        {
            int result;
            result = await HandleCrashBeforeAsync();
            result = await HandleCrashAfterAsync();
            result = await HandleCrashAfter2Async();
            result = await CrashAfterAsync();
        }

        public Task<int> CrashBeforeAsync()
        {
            throw new Exception("Boom");
        }

        public Task<int> CrashAfterAsync()
        {
            //return Task.FromResult(0)
            //    .ContinueWith<int>(t => throw new Exception("Boom"));
            return Task.FromException<int>(new Exception("Boom"));
        }

        public Task<int> HandleCrashBeforeAsync()
        {
            Task<int> resultTask;
            try
            {
                resultTask = CrashBeforeAsync();
            }
            catch (Exception) { throw; }
            return resultTask;
        }

        public async Task<int> HandleCrashAfterAsync()
        {
            Task<int> resultTask = CrashAfterAsync();
            int result;
            try
            {
                result = await resultTask;
            }
            catch (Exception) { throw; }
            return result;
        }

        public Task<int> HandleCrashAfter2Async()
        {
            Task<int> resultTask = CrashAfterAsync();
            try
            {
                return resultTask.ContinueWith<int>(t =>
                {
                    if (t.IsCompletedSuccessfully) return t.Result;
                    if(t.Exception.InnerException is OverflowException)
                        return -1;

                    throw t.Exception.InnerException;
                });                
            }
            catch (Exception) { throw; }
        }


    }
}
