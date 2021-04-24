using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SimpleMvvmAvalonia.Interfaces;

namespace SimpleMvvmAvalonia.Models
{
    public class Model : IModel
    {
        public event AddLogEvent AddLog;
        public event FinishedEvent Finished;

        public async Task WriteFileAsync(string file)
        {
            AddLog($"Запись в файл {file} начата!");

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("просто спим секунду");
                System.Threading.Thread.Sleep(1000);
            }

            Finished();
        }
    }
}