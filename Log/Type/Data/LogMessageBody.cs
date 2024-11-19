using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    /// <summary> 日志消息体 </summary>
    internal class LogMessageBody
    {
        public E_LogMaskShiftAmount shiftAmount;
        public DateTime time;
        public int threadId;
        public string message;

        public int Mask => 1 << (int)shiftAmount;

        public LogMessageBody(E_LogMaskShiftAmount shiftAmount, string message)
        {
            this.shiftAmount = shiftAmount;
            this.message = message;
            time = DateTime.Now;
            threadId = Thread.CurrentThread.ManagedThreadId;
        }

        public override string ToString()
        {
            return $"[{shiftAmount},{time:g},{threadId}], message:{message}";
        }

        public string ToString(LogMaskBody mask)
        { 
            if(mask == null)
                return ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append($"<color=#{mask.color.r.ToString("X2")}{mask.color.g:X2}{mask.color.b:X2}{mask.color.a:X2}>");
            sb.Append("[");
            sb.Append($"{mask.prefix} ");
            sb.Append($"{shiftAmount}");
            if (mask.showTime)
                sb.Append($",{time.ToString("yyyy/MM/dd HH:mm:ss")}");
            if (mask.showThreadID)
                sb.Append($",{threadId}");
            sb.Append("], message:");
            sb.Append(message);
            sb.Append("</color>");
            return sb.ToString();
        }
    }
}
