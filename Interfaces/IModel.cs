using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMvvmAvalonia.Interfaces
{
    public delegate void AddLogEvent(string message);
    public delegate void FinishedEvent();

    public interface IModel
    {
        event AddLogEvent AddLog;
        event FinishedEvent Finished;

        Task WriteFileAsync(string file);
    }
}