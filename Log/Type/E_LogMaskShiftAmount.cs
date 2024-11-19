using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    // MaskFlag: 遮罩标记 数个'位掩码'|运算得到值.
    // BitMask: 位掩码 例如1<<2操作后得到的值.
    // ShiftAmount: 操作量 例如1<<2操作中的2.

    /// <summary> 
    /// 左移量: int时取值于[0,31]
    /// </summary>
    public enum E_LogMaskShiftAmount
    {
        // 0 被定义为'全局输出', 仅是一种命名, 可以被停止输出。
        Global = 0,
        Amount1 = 1,
        Amount2 = 2,
        Amount3 = 3,
        Amount4 = 4,
        Amount5 = 5,
        Amount6 = 6,
        Amount7 = 7,
        Amount8 = 8,
        Amount9 = 9,
        Amount10 = 10,
        Amount11 = 11,
        Amount12 = 12,
        Amount13 = 13,
        Amount14 = 14,
        Amount15 = 15,
        Amount16 = 16,
        Amount17 = 17,
        Amount18 = 18,
        Amount19 = 19,
        Amount20 = 20,
        Amount21 = 21,
        Amount22 = 22,
        Amount23 = 23,
        Amount24 = 24,
        Amount25 = 25,
        Amount26 = 26,
        Amount27 = 27,
        Amount28 = 28,
        Amount29 = 29,
        Amount30 = 30,
        Amount31 = 31,
    }
}