using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    internal class QueueDebugerComponent : DebugerComponent
    {
        /// <summary> 消息缓冲区队列 </summary>
        protected Queue<LogMessageBody> messageCacheQue = new Queue<LogMessageBody>();

        /// <summary> 数据计入队列 </summary>
        internal override void Log(string message, E_LogMaskShiftAmount shiftAmountEnum)
        {
            messageCacheQue.Enqueue(new LogMessageBody(shiftAmountEnum, message));
        }

        /// <summary> 队列数据输出 </summary>
        internal void LogOut()
        {
            if (messageCacheQue.Count > 0)
            {
                Out(messageCacheQue.Dequeue());
            }
        }
    }
}