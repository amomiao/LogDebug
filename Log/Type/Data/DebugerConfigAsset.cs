using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    /// <summary> 负责配置'日志遮罩体' </summary>
    public class DebugerConfigAsset : ScriptableObject
    {
        public int maskFlag;
        public List<LogMaskBody> masks;

        public void Init()
        {
            masks = new List<LogMaskBody>()
            {
                new LogMaskBody(E_LogMaskShiftAmount.Global)
            };
            RefrushMaskFlag();
        }

        public void AddNewMask(E_LogMaskShiftAmount shiftAmount)
        {
            masks.Add(new LogMaskBody(shiftAmount));
        }

        public void RefrushMaskFlag()
        {
            maskFlag = 0;
            foreach (LogMaskBody mask in masks)
            {
                if (mask.isOpen)
                    maskFlag |= mask;
            }
        }

        /// <summary> 以枚举创建key,并将已配置的遮罩数据写进字典 </summary>
        public void GetMaskDic(out Dictionary<E_LogMaskShiftAmount, LogMaskBody> maskDic)
        {
            maskDic = new Dictionary<E_LogMaskShiftAmount, LogMaskBody>();
            foreach (E_LogMaskShiftAmount shift in (E_LogMaskShiftAmount[])Enum.GetValues(typeof(E_LogMaskShiftAmount)))
            {
                maskDic.Add(shift, null);
            }
            foreach (LogMaskBody mask in masks)
            {
                maskDic[mask.shiftAmount] = mask;
            }
        }
    }
}
