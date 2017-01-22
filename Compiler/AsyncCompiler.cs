using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Compiler
{
    public class AsyncCompiler
    {
        private readonly Compiler compiler;
        private readonly List<Task<byte[]>> tasks = new List<Task<byte[]>>();
        private int indexTask = 0;
        private object lockObject = new object();
        public AsyncCompiler()
        {
            compiler = new Compiler();
        }
        public async Task<byte[]> AsyncBuildProject(string pathFile)
        {
            if (tasks.Count == 0)
            {
                Task<byte[]> task = Task<byte[]>.Factory.StartNew(() => compiler.BuildProject(pathFile));
                lock (lockObject)
                {
                    tasks.Add(task);
                    indexTask = 0;
                }
                return await task;
            }
            else
            {
                Task<byte[]> queueTask = tasks[indexTask].ContinueWith<byte[]>((Task<byte[]> t) => compiler.BuildProject(pathFile));
                lock(lockObject)
                {
                    tasks.Add(queueTask);
                    indexTask++;
                }               
                return await queueTask;
            }
        }
    }
}
