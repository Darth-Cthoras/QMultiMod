﻿using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BetterScannerRoom.Patches
{
    [HarmonyPatch(typeof(uGUI_ResourceTracker))]
    [HarmonyPatch("GatherAll")]
    class uGUI_ResourceTracker_GatherAll_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(500f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, BSRSettings.Instance.ScannerBlipRange);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
