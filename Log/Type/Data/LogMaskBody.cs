using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    /// <summary> 日志遮罩体: 描述某个'掩码位'的Log是否输入,如何输入。 </summary>
    [Serializable]
    public class LogMaskBody
    {
        public static int operator |(int maskFlag, LogMaskBody maskBody)
        {
            return maskFlag | (1 << (int)maskBody.shiftAmount);
        }
        public static int operator &(int maskFlag, LogMaskBody maskBody)
        {
            return maskFlag & (1 << (int)maskBody.shiftAmount);
        }

        public E_LogMaskShiftAmount shiftAmount;
        public bool isOpen;
        public string prefix;
        public bool showTime;
        public bool showThreadID;
        public Color32 color;

        public LogMaskBody(E_LogMaskShiftAmount shiftAmount)
        {
            this.shiftAmount = shiftAmount;
            this.isOpen = true;
            this.prefix = string.Empty;
            this.showTime = true;
            this.showThreadID = true;
            this.color = Color.gray;
        }
    }
}