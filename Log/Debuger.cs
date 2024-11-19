using UnityEngine;

namespace Momos.Tools.DebugLog
{
    public static class Debuger
    {
        private static DebugerComponent outer;
        private static DebugerComponent Outer
        { 
            get
            {
                if (outer == null)
                    outer = new DebugerComponent();
                return outer;
            }
        }

        public static void Log(string message, E_LogMaskShiftAmount shiftAmountEnum)
            => Outer.Log(message, shiftAmountEnum);

        public static void LogGlobal(string message) => Log(message,E_LogMaskShiftAmount.Global);
    }
}