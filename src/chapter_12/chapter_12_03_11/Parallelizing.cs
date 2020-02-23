using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_11
{
    class Parallelizing
    {
        public async Task<byte[]> GetResourceAsync(string uri)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// You can test the error by uncommenting one of the
        /// lines inside the Linq query
        /// </summary>
        /// <returns></returns>
        public async Task NeedAll()
        {
            var uri = "https://picsum.photos/200";
            Task<byte[]>[] tasks = Enumerable.Range(0, 10)
                .Select(_ => GetResourceAsync(uri))
                //.Union(new Task<byte[]>[] { GetResourceAsync("http://bad") })
                //.Union(new Task<byte[]>[] { Task.FromException<byte[]>(new Exception("fail simulation")) })
                .ToArray();

            Task allTask = Task.WhenAll(tasks);
            try
            {
                await allTask;
            }
            catch (Exception)
            {
                Console.WriteLine("One or more downloads failed");
            }

            foreach (var completedTask in tasks)
                Console.WriteLine($"New image: {completedTask.Result.Length}");
        }

        /// <summary>
        /// Experiment by commenting WhenAny and uncommenting WhenAll
        /// to verify the download differences
        /// </summary>
        /// <returns></returns>
        public async Task NeedAny()
        {
            var sw = new Stopwatch();
            sw.Start();
            var uri = "https://picsum.photos/200";
            Task<byte[]>[] tasks = Enumerable.Range(0, 10)
                .Select(_ => GetResourceAsync(uri))
                .ToArray();

            while (tasks.Length > 0)
            {
                await Task.WhenAny(tasks);
                //await Task.WhenAll(Task.Delay(100), Task.WhenAny(tasks));
                var elapsed = sw.ElapsedMilliseconds;
                var completed = tasks.Where(t => t.IsCompleted).ToArray();
                foreach (var completedTask in completed)
                    Console.WriteLine($"{elapsed} New image: {completedTask.Result.Length}");
                tasks = tasks.Where(t => !t.IsCompletedSuccessfully).ToArray();
            }
        }

        /// <summary>
        /// Experiment by uncommenting the code inside the Linq query
        /// A download error will occur
        /// </summary>
        public void WaitAll()
        {
            var uri = "https://picsum.photos/200";
            Task<byte[]>[] tasks = Enumerable.Range(0, 10)
                .Select(_ => GetResourceAsync(uri))
                .Union(new Task<byte[]>[] { GetResourceAsync("http://bad") })
                //.Union(new Task<byte[]>[] { Task.FromException<byte[]>(new Exception("fail simulation")) })
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var completedTask in tasks)
                Console.WriteLine($"New image: {completedTask.Result.Length}");
        }


    }
}
