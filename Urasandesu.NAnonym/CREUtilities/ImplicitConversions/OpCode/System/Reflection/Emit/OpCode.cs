﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MC = Mono.Cecil;
using System.Reflection;
using System.Reflection.Emit;
using SR = System.Reflection;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using Urasandesu.NAnonym.Linq;

namespace Urasandesu.NAnonym.CREUtilities
{
    public sealed partial class OpCode
    {
        public static implicit operator OpCode(SR::Emit.OpCode opCode)
        {
            if (opCode == SR::Emit.OpCodes.Add) return OpCodes.Add;
            else if (opCode == SR::Emit.OpCodes.Add_Ovf) return OpCodes.Add_Ovf;
            else if (opCode == SR::Emit.OpCodes.Add_Ovf_Un) return OpCodes.Add_Ovf_Un;
            else if (opCode == SR::Emit.OpCodes.And) return OpCodes.And;
            else if (opCode == SR::Emit.OpCodes.Arglist) return OpCodes.Arglist;
            else if (opCode == SR::Emit.OpCodes.Beq) return OpCodes.Beq;
            else if (opCode == SR::Emit.OpCodes.Beq_S) return OpCodes.Beq_S;
            else if (opCode == SR::Emit.OpCodes.Bge) return OpCodes.Bge;
            else if (opCode == SR::Emit.OpCodes.Bge_S) return OpCodes.Bge_S;
            else if (opCode == SR::Emit.OpCodes.Bge_Un) return OpCodes.Bge_Un;
            else if (opCode == SR::Emit.OpCodes.Bge_Un_S) return OpCodes.Bge_Un_S;
            else if (opCode == SR::Emit.OpCodes.Bgt) return OpCodes.Bgt;
            else if (opCode == SR::Emit.OpCodes.Bgt_S) return OpCodes.Bgt_S;
            else if (opCode == SR::Emit.OpCodes.Bgt_Un) return OpCodes.Bgt_Un;
            else if (opCode == SR::Emit.OpCodes.Bgt_Un_S) return OpCodes.Bgt_Un_S;
            else if (opCode == SR::Emit.OpCodes.Ble) return OpCodes.Ble;
            else if (opCode == SR::Emit.OpCodes.Ble_S) return OpCodes.Ble_S;
            else if (opCode == SR::Emit.OpCodes.Ble_Un) return OpCodes.Ble_Un;
            else if (opCode == SR::Emit.OpCodes.Ble_Un_S) return OpCodes.Ble_Un_S;
            else if (opCode == SR::Emit.OpCodes.Blt) return OpCodes.Blt;
            else if (opCode == SR::Emit.OpCodes.Blt_S) return OpCodes.Blt_S;
            else if (opCode == SR::Emit.OpCodes.Blt_Un) return OpCodes.Blt_Un;
            else if (opCode == SR::Emit.OpCodes.Blt_Un_S) return OpCodes.Blt_Un_S;
            else if (opCode == SR::Emit.OpCodes.Bne_Un) return OpCodes.Bne_Un;
            else if (opCode == SR::Emit.OpCodes.Bne_Un_S) return OpCodes.Bne_Un_S;
            else if (opCode == SR::Emit.OpCodes.Box) return OpCodes.Box;
            else if (opCode == SR::Emit.OpCodes.Br) return OpCodes.Br;
            else if (opCode == SR::Emit.OpCodes.Br_S) return OpCodes.Br_S;
            else if (opCode == SR::Emit.OpCodes.Break) return OpCodes.Break;
            else if (opCode == SR::Emit.OpCodes.Brfalse) return OpCodes.Brfalse;
            else if (opCode == SR::Emit.OpCodes.Brfalse_S) return OpCodes.Brfalse_S;
            else if (opCode == SR::Emit.OpCodes.Brtrue) return OpCodes.Brtrue;
            else if (opCode == SR::Emit.OpCodes.Brtrue_S) return OpCodes.Brtrue_S;
            else if (opCode == SR::Emit.OpCodes.Call) return OpCodes.Call;
            else if (opCode == SR::Emit.OpCodes.Calli) return OpCodes.Calli;
            else if (opCode == SR::Emit.OpCodes.Callvirt) return OpCodes.Callvirt;
            else if (opCode == SR::Emit.OpCodes.Castclass) return OpCodes.Castclass;
            else if (opCode == SR::Emit.OpCodes.Ceq) return OpCodes.Ceq;
            else if (opCode == SR::Emit.OpCodes.Cgt) return OpCodes.Cgt;
            else if (opCode == SR::Emit.OpCodes.Cgt_Un) return OpCodes.Cgt_Un;
            else if (opCode == SR::Emit.OpCodes.Ckfinite) return OpCodes.Ckfinite;
            else if (opCode == SR::Emit.OpCodes.Clt) return OpCodes.Clt;
            else if (opCode == SR::Emit.OpCodes.Clt_Un) return OpCodes.Clt_Un;
            else if (opCode == SR::Emit.OpCodes.Constrained) return OpCodes.Constrained;
            else if (opCode == SR::Emit.OpCodes.Conv_I) return OpCodes.Conv_I;
            else if (opCode == SR::Emit.OpCodes.Conv_I1) return OpCodes.Conv_I1;
            else if (opCode == SR::Emit.OpCodes.Conv_I2) return OpCodes.Conv_I2;
            else if (opCode == SR::Emit.OpCodes.Conv_I4) return OpCodes.Conv_I4;
            else if (opCode == SR::Emit.OpCodes.Conv_I8) return OpCodes.Conv_I8;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I) return OpCodes.Conv_Ovf_I;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I_Un) return OpCodes.Conv_Ovf_I_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I1) return OpCodes.Conv_Ovf_I1;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I1_Un) return OpCodes.Conv_Ovf_I1_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I2) return OpCodes.Conv_Ovf_I2;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I2_Un) return OpCodes.Conv_Ovf_I2_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I4) return OpCodes.Conv_Ovf_I4;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I4_Un) return OpCodes.Conv_Ovf_I4_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I8) return OpCodes.Conv_Ovf_I8;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_I8_Un) return OpCodes.Conv_Ovf_I8_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U) return OpCodes.Conv_Ovf_U;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U_Un) return OpCodes.Conv_Ovf_U_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U1) return OpCodes.Conv_Ovf_U1;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U1_Un) return OpCodes.Conv_Ovf_U1_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U2) return OpCodes.Conv_Ovf_U2;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U2_Un) return OpCodes.Conv_Ovf_U2_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U4) return OpCodes.Conv_Ovf_U4;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U4_Un) return OpCodes.Conv_Ovf_U4_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U8) return OpCodes.Conv_Ovf_U8;
            else if (opCode == SR::Emit.OpCodes.Conv_Ovf_U8_Un) return OpCodes.Conv_Ovf_U8_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_R_Un) return OpCodes.Conv_R_Un;
            else if (opCode == SR::Emit.OpCodes.Conv_R4) return OpCodes.Conv_R4;
            else if (opCode == SR::Emit.OpCodes.Conv_R8) return OpCodes.Conv_R8;
            else if (opCode == SR::Emit.OpCodes.Conv_U) return OpCodes.Conv_U;
            else if (opCode == SR::Emit.OpCodes.Conv_U1) return OpCodes.Conv_U1;
            else if (opCode == SR::Emit.OpCodes.Conv_U2) return OpCodes.Conv_U2;
            else if (opCode == SR::Emit.OpCodes.Conv_U4) return OpCodes.Conv_U4;
            else if (opCode == SR::Emit.OpCodes.Conv_U8) return OpCodes.Conv_U8;
            else if (opCode == SR::Emit.OpCodes.Cpblk) return OpCodes.Cpblk;
            else if (opCode == SR::Emit.OpCodes.Cpobj) return OpCodes.Cpobj;
            else if (opCode == SR::Emit.OpCodes.Div) return OpCodes.Div;
            else if (opCode == SR::Emit.OpCodes.Div_Un) return OpCodes.Div_Un;
            else if (opCode == SR::Emit.OpCodes.Dup) return OpCodes.Dup;
            else if (opCode == SR::Emit.OpCodes.Endfilter) return OpCodes.Endfilter;
            else if (opCode == SR::Emit.OpCodes.Endfinally) return OpCodes.Endfinally;
            else if (opCode == SR::Emit.OpCodes.Initblk) return OpCodes.Initblk;
            else if (opCode == SR::Emit.OpCodes.Initobj) return OpCodes.Initobj;
            else if (opCode == SR::Emit.OpCodes.Isinst) return OpCodes.Isinst;
            else if (opCode == SR::Emit.OpCodes.Jmp) return OpCodes.Jmp;
            else if (opCode == SR::Emit.OpCodes.Ldarg) return OpCodes.Ldarg;
            else if (opCode == SR::Emit.OpCodes.Ldarg_0) return OpCodes.Ldarg_0;
            else if (opCode == SR::Emit.OpCodes.Ldarg_1) return OpCodes.Ldarg_1;
            else if (opCode == SR::Emit.OpCodes.Ldarg_2) return OpCodes.Ldarg_2;
            else if (opCode == SR::Emit.OpCodes.Ldarg_3) return OpCodes.Ldarg_3;
            else if (opCode == SR::Emit.OpCodes.Ldarg_S) return OpCodes.Ldarg_S;
            else if (opCode == SR::Emit.OpCodes.Ldarga) return OpCodes.Ldarga;
            else if (opCode == SR::Emit.OpCodes.Ldarga_S) return OpCodes.Ldarga_S;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4) return OpCodes.Ldc_I4;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_0) return OpCodes.Ldc_I4_0;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_1) return OpCodes.Ldc_I4_1;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_2) return OpCodes.Ldc_I4_2;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_3) return OpCodes.Ldc_I4_3;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_4) return OpCodes.Ldc_I4_4;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_5) return OpCodes.Ldc_I4_5;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_6) return OpCodes.Ldc_I4_6;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_7) return OpCodes.Ldc_I4_7;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_8) return OpCodes.Ldc_I4_8;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_M1) return OpCodes.Ldc_I4_M1;
            else if (opCode == SR::Emit.OpCodes.Ldc_I4_S) return OpCodes.Ldc_I4_S;
            else if (opCode == SR::Emit.OpCodes.Ldc_I8) return OpCodes.Ldc_I8;
            else if (opCode == SR::Emit.OpCodes.Ldc_R4) return OpCodes.Ldc_R4;
            else if (opCode == SR::Emit.OpCodes.Ldc_R8) return OpCodes.Ldc_R8;
            else if (opCode == SR::Emit.OpCodes.Ldelem) return OpCodes.Ldelem;
            else if (opCode == SR::Emit.OpCodes.Ldelem_I) return OpCodes.Ldelem_I;
            else if (opCode == SR::Emit.OpCodes.Ldelem_I1) return OpCodes.Ldelem_I1;
            else if (opCode == SR::Emit.OpCodes.Ldelem_I2) return OpCodes.Ldelem_I2;
            else if (opCode == SR::Emit.OpCodes.Ldelem_I4) return OpCodes.Ldelem_I4;
            else if (opCode == SR::Emit.OpCodes.Ldelem_I8) return OpCodes.Ldelem_I8;
            else if (opCode == SR::Emit.OpCodes.Ldelem_R4) return OpCodes.Ldelem_R4;
            else if (opCode == SR::Emit.OpCodes.Ldelem_R8) return OpCodes.Ldelem_R8;
            else if (opCode == SR::Emit.OpCodes.Ldelem_Ref) return OpCodes.Ldelem_Ref;
            else if (opCode == SR::Emit.OpCodes.Ldelem_U1) return OpCodes.Ldelem_U1;
            else if (opCode == SR::Emit.OpCodes.Ldelem_U2) return OpCodes.Ldelem_U2;
            else if (opCode == SR::Emit.OpCodes.Ldelem_U4) return OpCodes.Ldelem_U4;
            else if (opCode == SR::Emit.OpCodes.Ldelema) return OpCodes.Ldelema;
            else if (opCode == SR::Emit.OpCodes.Ldfld) return OpCodes.Ldfld;
            else if (opCode == SR::Emit.OpCodes.Ldflda) return OpCodes.Ldflda;
            else if (opCode == SR::Emit.OpCodes.Ldftn) return OpCodes.Ldftn;
            else if (opCode == SR::Emit.OpCodes.Ldind_I) return OpCodes.Ldind_I;
            else if (opCode == SR::Emit.OpCodes.Ldind_I1) return OpCodes.Ldind_I1;
            else if (opCode == SR::Emit.OpCodes.Ldind_I2) return OpCodes.Ldind_I2;
            else if (opCode == SR::Emit.OpCodes.Ldind_I4) return OpCodes.Ldind_I4;
            else if (opCode == SR::Emit.OpCodes.Ldind_I8) return OpCodes.Ldind_I8;
            else if (opCode == SR::Emit.OpCodes.Ldind_R4) return OpCodes.Ldind_R4;
            else if (opCode == SR::Emit.OpCodes.Ldind_R8) return OpCodes.Ldind_R8;
            else if (opCode == SR::Emit.OpCodes.Ldind_Ref) return OpCodes.Ldind_Ref;
            else if (opCode == SR::Emit.OpCodes.Ldind_U1) return OpCodes.Ldind_U1;
            else if (opCode == SR::Emit.OpCodes.Ldind_U2) return OpCodes.Ldind_U2;
            else if (opCode == SR::Emit.OpCodes.Ldind_U4) return OpCodes.Ldind_U4;
            else if (opCode == SR::Emit.OpCodes.Ldlen) return OpCodes.Ldlen;
            else if (opCode == SR::Emit.OpCodes.Ldloc) return OpCodes.Ldloc;
            else if (opCode == SR::Emit.OpCodes.Ldloc_0) return OpCodes.Ldloc_0;
            else if (opCode == SR::Emit.OpCodes.Ldloc_1) return OpCodes.Ldloc_1;
            else if (opCode == SR::Emit.OpCodes.Ldloc_2) return OpCodes.Ldloc_2;
            else if (opCode == SR::Emit.OpCodes.Ldloc_3) return OpCodes.Ldloc_3;
            else if (opCode == SR::Emit.OpCodes.Ldloc_S) return OpCodes.Ldloc_S;
            else if (opCode == SR::Emit.OpCodes.Ldloca) return OpCodes.Ldloca;
            else if (opCode == SR::Emit.OpCodes.Ldloca_S) return OpCodes.Ldloca_S;
            else if (opCode == SR::Emit.OpCodes.Ldnull) return OpCodes.Ldnull;
            else if (opCode == SR::Emit.OpCodes.Ldobj) return OpCodes.Ldobj;
            else if (opCode == SR::Emit.OpCodes.Ldsfld) return OpCodes.Ldsfld;
            else if (opCode == SR::Emit.OpCodes.Ldsflda) return OpCodes.Ldsflda;
            else if (opCode == SR::Emit.OpCodes.Ldstr) return OpCodes.Ldstr;
            else if (opCode == SR::Emit.OpCodes.Ldtoken) return OpCodes.Ldtoken;
            else if (opCode == SR::Emit.OpCodes.Ldvirtftn) return OpCodes.Ldvirtftn;
            else if (opCode == SR::Emit.OpCodes.Leave) return OpCodes.Leave;
            else if (opCode == SR::Emit.OpCodes.Leave_S) return OpCodes.Leave_S;
            else if (opCode == SR::Emit.OpCodes.Localloc) return OpCodes.Localloc;
            else if (opCode == SR::Emit.OpCodes.Mkrefany) return OpCodes.Mkrefany;
            else if (opCode == SR::Emit.OpCodes.Mul) return OpCodes.Mul;
            else if (opCode == SR::Emit.OpCodes.Mul_Ovf) return OpCodes.Mul_Ovf;
            else if (opCode == SR::Emit.OpCodes.Mul_Ovf_Un) return OpCodes.Mul_Ovf_Un;
            else if (opCode == SR::Emit.OpCodes.Neg) return OpCodes.Neg;
            else if (opCode == SR::Emit.OpCodes.Newarr) return OpCodes.Newarr;
            else if (opCode == SR::Emit.OpCodes.Newobj) return OpCodes.Newobj;
            else if (opCode == SR::Emit.OpCodes.Nop) return OpCodes.Nop;
            else if (opCode == SR::Emit.OpCodes.Not) return OpCodes.Not;
            else if (opCode == SR::Emit.OpCodes.Or) return OpCodes.Or;
            else if (opCode == SR::Emit.OpCodes.Pop) return OpCodes.Pop;
            else if (opCode == SR::Emit.OpCodes.Readonly) return OpCodes.Readonly;
            else if (opCode == SR::Emit.OpCodes.Refanytype) return OpCodes.Refanytype;
            else if (opCode == SR::Emit.OpCodes.Refanyval) return OpCodes.Refanyval;
            else if (opCode == SR::Emit.OpCodes.Rem) return OpCodes.Rem;
            else if (opCode == SR::Emit.OpCodes.Rem_Un) return OpCodes.Rem_Un;
            else if (opCode == SR::Emit.OpCodes.Ret) return OpCodes.Ret;
            else if (opCode == SR::Emit.OpCodes.Rethrow) return OpCodes.Rethrow;
            else if (opCode == SR::Emit.OpCodes.Shl) return OpCodes.Shl;
            else if (opCode == SR::Emit.OpCodes.Shr) return OpCodes.Shr;
            else if (opCode == SR::Emit.OpCodes.Shr_Un) return OpCodes.Shr_Un;
            else if (opCode == SR::Emit.OpCodes.Sizeof) return OpCodes.Sizeof;
            else if (opCode == SR::Emit.OpCodes.Starg) return OpCodes.Starg;
            else if (opCode == SR::Emit.OpCodes.Starg_S) return OpCodes.Starg_S;
            else if (opCode == SR::Emit.OpCodes.Stelem) return OpCodes.Stelem;
            else if (opCode == SR::Emit.OpCodes.Stelem_I) return OpCodes.Stelem_I;
            else if (opCode == SR::Emit.OpCodes.Stelem_I1) return OpCodes.Stelem_I1;
            else if (opCode == SR::Emit.OpCodes.Stelem_I2) return OpCodes.Stelem_I2;
            else if (opCode == SR::Emit.OpCodes.Stelem_I4) return OpCodes.Stelem_I4;
            else if (opCode == SR::Emit.OpCodes.Stelem_I8) return OpCodes.Stelem_I8;
            else if (opCode == SR::Emit.OpCodes.Stelem_R4) return OpCodes.Stelem_R4;
            else if (opCode == SR::Emit.OpCodes.Stelem_R8) return OpCodes.Stelem_R8;
            else if (opCode == SR::Emit.OpCodes.Stelem_Ref) return OpCodes.Stelem_Ref;
            else if (opCode == SR::Emit.OpCodes.Stfld) return OpCodes.Stfld;
            else if (opCode == SR::Emit.OpCodes.Stind_I) return OpCodes.Stind_I;
            else if (opCode == SR::Emit.OpCodes.Stind_I1) return OpCodes.Stind_I1;
            else if (opCode == SR::Emit.OpCodes.Stind_I2) return OpCodes.Stind_I2;
            else if (opCode == SR::Emit.OpCodes.Stind_I4) return OpCodes.Stind_I4;
            else if (opCode == SR::Emit.OpCodes.Stind_I8) return OpCodes.Stind_I8;
            else if (opCode == SR::Emit.OpCodes.Stind_R4) return OpCodes.Stind_R4;
            else if (opCode == SR::Emit.OpCodes.Stind_R8) return OpCodes.Stind_R8;
            else if (opCode == SR::Emit.OpCodes.Stind_Ref) return OpCodes.Stind_Ref;
            else if (opCode == SR::Emit.OpCodes.Stloc) return OpCodes.Stloc;
            else if (opCode == SR::Emit.OpCodes.Stloc_0) return OpCodes.Stloc_0;
            else if (opCode == SR::Emit.OpCodes.Stloc_1) return OpCodes.Stloc_1;
            else if (opCode == SR::Emit.OpCodes.Stloc_2) return OpCodes.Stloc_2;
            else if (opCode == SR::Emit.OpCodes.Stloc_3) return OpCodes.Stloc_3;
            else if (opCode == SR::Emit.OpCodes.Stloc_S) return OpCodes.Stloc_S;
            else if (opCode == SR::Emit.OpCodes.Stobj) return OpCodes.Stobj;
            else if (opCode == SR::Emit.OpCodes.Stsfld) return OpCodes.Stsfld;
            else if (opCode == SR::Emit.OpCodes.Sub) return OpCodes.Sub;
            else if (opCode == SR::Emit.OpCodes.Sub_Ovf) return OpCodes.Sub_Ovf;
            else if (opCode == SR::Emit.OpCodes.Sub_Ovf_Un) return OpCodes.Sub_Ovf_Un;
            else if (opCode == SR::Emit.OpCodes.Switch) return OpCodes.Switch;
            else if (opCode == SR::Emit.OpCodes.Tailcall) return OpCodes.Tailcall;
            else if (opCode == SR::Emit.OpCodes.Throw) return OpCodes.Throw;
            else if (opCode == SR::Emit.OpCodes.Unaligned) return OpCodes.Unaligned;
            else if (opCode == SR::Emit.OpCodes.Unbox) return OpCodes.Unbox;
            else if (opCode == SR::Emit.OpCodes.Unbox_Any) return OpCodes.Unbox_Any;
            else if (opCode == SR::Emit.OpCodes.Volatile) return OpCodes.Volatile;
            else if (opCode == SR::Emit.OpCodes.Xor) return OpCodes.Xor;

            throw new NotSupportedException();
        }

        public static implicit operator SR::Emit.OpCode(OpCode opCode)
        {
            if (opCode == OpCodes.Add) return SR::Emit.OpCodes.Add;
            else if (opCode == OpCodes.Add_Ovf) return SR::Emit.OpCodes.Add_Ovf;
            else if (opCode == OpCodes.Add_Ovf_Un) return SR::Emit.OpCodes.Add_Ovf_Un;
            else if (opCode == OpCodes.And) return SR::Emit.OpCodes.And;
            else if (opCode == OpCodes.Arglist) return SR::Emit.OpCodes.Arglist;
            else if (opCode == OpCodes.Beq) return SR::Emit.OpCodes.Beq;
            else if (opCode == OpCodes.Beq_S) return SR::Emit.OpCodes.Beq_S;
            else if (opCode == OpCodes.Bge) return SR::Emit.OpCodes.Bge;
            else if (opCode == OpCodes.Bge_S) return SR::Emit.OpCodes.Bge_S;
            else if (opCode == OpCodes.Bge_Un) return SR::Emit.OpCodes.Bge_Un;
            else if (opCode == OpCodes.Bge_Un_S) return SR::Emit.OpCodes.Bge_Un_S;
            else if (opCode == OpCodes.Bgt) return SR::Emit.OpCodes.Bgt;
            else if (opCode == OpCodes.Bgt_S) return SR::Emit.OpCodes.Bgt_S;
            else if (opCode == OpCodes.Bgt_Un) return SR::Emit.OpCodes.Bgt_Un;
            else if (opCode == OpCodes.Bgt_Un_S) return SR::Emit.OpCodes.Bgt_Un_S;
            else if (opCode == OpCodes.Ble) return SR::Emit.OpCodes.Ble;
            else if (opCode == OpCodes.Ble_S) return SR::Emit.OpCodes.Ble_S;
            else if (opCode == OpCodes.Ble_Un) return SR::Emit.OpCodes.Ble_Un;
            else if (opCode == OpCodes.Ble_Un_S) return SR::Emit.OpCodes.Ble_Un_S;
            else if (opCode == OpCodes.Blt) return SR::Emit.OpCodes.Blt;
            else if (opCode == OpCodes.Blt_S) return SR::Emit.OpCodes.Blt_S;
            else if (opCode == OpCodes.Blt_Un) return SR::Emit.OpCodes.Blt_Un;
            else if (opCode == OpCodes.Blt_Un_S) return SR::Emit.OpCodes.Blt_Un_S;
            else if (opCode == OpCodes.Bne_Un) return SR::Emit.OpCodes.Bne_Un;
            else if (opCode == OpCodes.Bne_Un_S) return SR::Emit.OpCodes.Bne_Un_S;
            else if (opCode == OpCodes.Box) return SR::Emit.OpCodes.Box;
            else if (opCode == OpCodes.Br) return SR::Emit.OpCodes.Br;
            else if (opCode == OpCodes.Br_S) return SR::Emit.OpCodes.Br_S;
            else if (opCode == OpCodes.Break) return SR::Emit.OpCodes.Break;
            else if (opCode == OpCodes.Brfalse) return SR::Emit.OpCodes.Brfalse;
            else if (opCode == OpCodes.Brfalse_S) return SR::Emit.OpCodes.Brfalse_S;
            else if (opCode == OpCodes.Brtrue) return SR::Emit.OpCodes.Brtrue;
            else if (opCode == OpCodes.Brtrue_S) return SR::Emit.OpCodes.Brtrue_S;
            else if (opCode == OpCodes.Call) return SR::Emit.OpCodes.Call;
            else if (opCode == OpCodes.Calli) return SR::Emit.OpCodes.Calli;
            else if (opCode == OpCodes.Callvirt) return SR::Emit.OpCodes.Callvirt;
            else if (opCode == OpCodes.Castclass) return SR::Emit.OpCodes.Castclass;
            else if (opCode == OpCodes.Ceq) return SR::Emit.OpCodes.Ceq;
            else if (opCode == OpCodes.Cgt) return SR::Emit.OpCodes.Cgt;
            else if (opCode == OpCodes.Cgt_Un) return SR::Emit.OpCodes.Cgt_Un;
            else if (opCode == OpCodes.Ckfinite) return SR::Emit.OpCodes.Ckfinite;
            else if (opCode == OpCodes.Clt) return SR::Emit.OpCodes.Clt;
            else if (opCode == OpCodes.Clt_Un) return SR::Emit.OpCodes.Clt_Un;
            else if (opCode == OpCodes.Constrained) return SR::Emit.OpCodes.Constrained;
            else if (opCode == OpCodes.Conv_I) return SR::Emit.OpCodes.Conv_I;
            else if (opCode == OpCodes.Conv_I1) return SR::Emit.OpCodes.Conv_I1;
            else if (opCode == OpCodes.Conv_I2) return SR::Emit.OpCodes.Conv_I2;
            else if (opCode == OpCodes.Conv_I4) return SR::Emit.OpCodes.Conv_I4;
            else if (opCode == OpCodes.Conv_I8) return SR::Emit.OpCodes.Conv_I8;
            else if (opCode == OpCodes.Conv_Ovf_I) return SR::Emit.OpCodes.Conv_Ovf_I;
            else if (opCode == OpCodes.Conv_Ovf_I_Un) return SR::Emit.OpCodes.Conv_Ovf_I_Un;
            else if (opCode == OpCodes.Conv_Ovf_I1) return SR::Emit.OpCodes.Conv_Ovf_I1;
            else if (opCode == OpCodes.Conv_Ovf_I1_Un) return SR::Emit.OpCodes.Conv_Ovf_I1_Un;
            else if (opCode == OpCodes.Conv_Ovf_I2) return SR::Emit.OpCodes.Conv_Ovf_I2;
            else if (opCode == OpCodes.Conv_Ovf_I2_Un) return SR::Emit.OpCodes.Conv_Ovf_I2_Un;
            else if (opCode == OpCodes.Conv_Ovf_I4) return SR::Emit.OpCodes.Conv_Ovf_I4;
            else if (opCode == OpCodes.Conv_Ovf_I4_Un) return SR::Emit.OpCodes.Conv_Ovf_I4_Un;
            else if (opCode == OpCodes.Conv_Ovf_I8) return SR::Emit.OpCodes.Conv_Ovf_I8;
            else if (opCode == OpCodes.Conv_Ovf_I8_Un) return SR::Emit.OpCodes.Conv_Ovf_I8_Un;
            else if (opCode == OpCodes.Conv_Ovf_U) return SR::Emit.OpCodes.Conv_Ovf_U;
            else if (opCode == OpCodes.Conv_Ovf_U_Un) return SR::Emit.OpCodes.Conv_Ovf_U_Un;
            else if (opCode == OpCodes.Conv_Ovf_U1) return SR::Emit.OpCodes.Conv_Ovf_U1;
            else if (opCode == OpCodes.Conv_Ovf_U1_Un) return SR::Emit.OpCodes.Conv_Ovf_U1_Un;
            else if (opCode == OpCodes.Conv_Ovf_U2) return SR::Emit.OpCodes.Conv_Ovf_U2;
            else if (opCode == OpCodes.Conv_Ovf_U2_Un) return SR::Emit.OpCodes.Conv_Ovf_U2_Un;
            else if (opCode == OpCodes.Conv_Ovf_U4) return SR::Emit.OpCodes.Conv_Ovf_U4;
            else if (opCode == OpCodes.Conv_Ovf_U4_Un) return SR::Emit.OpCodes.Conv_Ovf_U4_Un;
            else if (opCode == OpCodes.Conv_Ovf_U8) return SR::Emit.OpCodes.Conv_Ovf_U8;
            else if (opCode == OpCodes.Conv_Ovf_U8_Un) return SR::Emit.OpCodes.Conv_Ovf_U8_Un;
            else if (opCode == OpCodes.Conv_R_Un) return SR::Emit.OpCodes.Conv_R_Un;
            else if (opCode == OpCodes.Conv_R4) return SR::Emit.OpCodes.Conv_R4;
            else if (opCode == OpCodes.Conv_R8) return SR::Emit.OpCodes.Conv_R8;
            else if (opCode == OpCodes.Conv_U) return SR::Emit.OpCodes.Conv_U;
            else if (opCode == OpCodes.Conv_U1) return SR::Emit.OpCodes.Conv_U1;
            else if (opCode == OpCodes.Conv_U2) return SR::Emit.OpCodes.Conv_U2;
            else if (opCode == OpCodes.Conv_U4) return SR::Emit.OpCodes.Conv_U4;
            else if (opCode == OpCodes.Conv_U8) return SR::Emit.OpCodes.Conv_U8;
            else if (opCode == OpCodes.Cpblk) return SR::Emit.OpCodes.Cpblk;
            else if (opCode == OpCodes.Cpobj) return SR::Emit.OpCodes.Cpobj;
            else if (opCode == OpCodes.Div) return SR::Emit.OpCodes.Div;
            else if (opCode == OpCodes.Div_Un) return SR::Emit.OpCodes.Div_Un;
            else if (opCode == OpCodes.Dup) return SR::Emit.OpCodes.Dup;
            else if (opCode == OpCodes.Endfilter) return SR::Emit.OpCodes.Endfilter;
            else if (opCode == OpCodes.Endfinally) return SR::Emit.OpCodes.Endfinally;
            else if (opCode == OpCodes.Initblk) return SR::Emit.OpCodes.Initblk;
            else if (opCode == OpCodes.Initobj) return SR::Emit.OpCodes.Initobj;
            else if (opCode == OpCodes.Isinst) return SR::Emit.OpCodes.Isinst;
            else if (opCode == OpCodes.Jmp) return SR::Emit.OpCodes.Jmp;
            else if (opCode == OpCodes.Ldarg) return SR::Emit.OpCodes.Ldarg;
            else if (opCode == OpCodes.Ldarg_0) return SR::Emit.OpCodes.Ldarg_0;
            else if (opCode == OpCodes.Ldarg_1) return SR::Emit.OpCodes.Ldarg_1;
            else if (opCode == OpCodes.Ldarg_2) return SR::Emit.OpCodes.Ldarg_2;
            else if (opCode == OpCodes.Ldarg_3) return SR::Emit.OpCodes.Ldarg_3;
            else if (opCode == OpCodes.Ldarg_S) return SR::Emit.OpCodes.Ldarg_S;
            else if (opCode == OpCodes.Ldarga) return SR::Emit.OpCodes.Ldarga;
            else if (opCode == OpCodes.Ldarga_S) return SR::Emit.OpCodes.Ldarga_S;
            else if (opCode == OpCodes.Ldc_I4) return SR::Emit.OpCodes.Ldc_I4;
            else if (opCode == OpCodes.Ldc_I4_0) return SR::Emit.OpCodes.Ldc_I4_0;
            else if (opCode == OpCodes.Ldc_I4_1) return SR::Emit.OpCodes.Ldc_I4_1;
            else if (opCode == OpCodes.Ldc_I4_2) return SR::Emit.OpCodes.Ldc_I4_2;
            else if (opCode == OpCodes.Ldc_I4_3) return SR::Emit.OpCodes.Ldc_I4_3;
            else if (opCode == OpCodes.Ldc_I4_4) return SR::Emit.OpCodes.Ldc_I4_4;
            else if (opCode == OpCodes.Ldc_I4_5) return SR::Emit.OpCodes.Ldc_I4_5;
            else if (opCode == OpCodes.Ldc_I4_6) return SR::Emit.OpCodes.Ldc_I4_6;
            else if (opCode == OpCodes.Ldc_I4_7) return SR::Emit.OpCodes.Ldc_I4_7;
            else if (opCode == OpCodes.Ldc_I4_8) return SR::Emit.OpCodes.Ldc_I4_8;
            else if (opCode == OpCodes.Ldc_I4_M1) return SR::Emit.OpCodes.Ldc_I4_M1;
            else if (opCode == OpCodes.Ldc_I4_S) return SR::Emit.OpCodes.Ldc_I4_S;
            else if (opCode == OpCodes.Ldc_I8) return SR::Emit.OpCodes.Ldc_I8;
            else if (opCode == OpCodes.Ldc_R4) return SR::Emit.OpCodes.Ldc_R4;
            else if (opCode == OpCodes.Ldc_R8) return SR::Emit.OpCodes.Ldc_R8;
            else if (opCode == OpCodes.Ldelem) return SR::Emit.OpCodes.Ldelem;
            else if (opCode == OpCodes.Ldelem_I) return SR::Emit.OpCodes.Ldelem_I;
            else if (opCode == OpCodes.Ldelem_I1) return SR::Emit.OpCodes.Ldelem_I1;
            else if (opCode == OpCodes.Ldelem_I2) return SR::Emit.OpCodes.Ldelem_I2;
            else if (opCode == OpCodes.Ldelem_I4) return SR::Emit.OpCodes.Ldelem_I4;
            else if (opCode == OpCodes.Ldelem_I8) return SR::Emit.OpCodes.Ldelem_I8;
            else if (opCode == OpCodes.Ldelem_R4) return SR::Emit.OpCodes.Ldelem_R4;
            else if (opCode == OpCodes.Ldelem_R8) return SR::Emit.OpCodes.Ldelem_R8;
            else if (opCode == OpCodes.Ldelem_Ref) return SR::Emit.OpCodes.Ldelem_Ref;
            else if (opCode == OpCodes.Ldelem_U1) return SR::Emit.OpCodes.Ldelem_U1;
            else if (opCode == OpCodes.Ldelem_U2) return SR::Emit.OpCodes.Ldelem_U2;
            else if (opCode == OpCodes.Ldelem_U4) return SR::Emit.OpCodes.Ldelem_U4;
            else if (opCode == OpCodes.Ldelema) return SR::Emit.OpCodes.Ldelema;
            else if (opCode == OpCodes.Ldfld) return SR::Emit.OpCodes.Ldfld;
            else if (opCode == OpCodes.Ldflda) return SR::Emit.OpCodes.Ldflda;
            else if (opCode == OpCodes.Ldftn) return SR::Emit.OpCodes.Ldftn;
            else if (opCode == OpCodes.Ldind_I) return SR::Emit.OpCodes.Ldind_I;
            else if (opCode == OpCodes.Ldind_I1) return SR::Emit.OpCodes.Ldind_I1;
            else if (opCode == OpCodes.Ldind_I2) return SR::Emit.OpCodes.Ldind_I2;
            else if (opCode == OpCodes.Ldind_I4) return SR::Emit.OpCodes.Ldind_I4;
            else if (opCode == OpCodes.Ldind_I8) return SR::Emit.OpCodes.Ldind_I8;
            else if (opCode == OpCodes.Ldind_R4) return SR::Emit.OpCodes.Ldind_R4;
            else if (opCode == OpCodes.Ldind_R8) return SR::Emit.OpCodes.Ldind_R8;
            else if (opCode == OpCodes.Ldind_Ref) return SR::Emit.OpCodes.Ldind_Ref;
            else if (opCode == OpCodes.Ldind_U1) return SR::Emit.OpCodes.Ldind_U1;
            else if (opCode == OpCodes.Ldind_U2) return SR::Emit.OpCodes.Ldind_U2;
            else if (opCode == OpCodes.Ldind_U4) return SR::Emit.OpCodes.Ldind_U4;
            else if (opCode == OpCodes.Ldlen) return SR::Emit.OpCodes.Ldlen;
            else if (opCode == OpCodes.Ldloc) return SR::Emit.OpCodes.Ldloc;
            else if (opCode == OpCodes.Ldloc_0) return SR::Emit.OpCodes.Ldloc_0;
            else if (opCode == OpCodes.Ldloc_1) return SR::Emit.OpCodes.Ldloc_1;
            else if (opCode == OpCodes.Ldloc_2) return SR::Emit.OpCodes.Ldloc_2;
            else if (opCode == OpCodes.Ldloc_3) return SR::Emit.OpCodes.Ldloc_3;
            else if (opCode == OpCodes.Ldloc_S) return SR::Emit.OpCodes.Ldloc_S;
            else if (opCode == OpCodes.Ldloca) return SR::Emit.OpCodes.Ldloca;
            else if (opCode == OpCodes.Ldloca_S) return SR::Emit.OpCodes.Ldloca_S;
            else if (opCode == OpCodes.Ldnull) return SR::Emit.OpCodes.Ldnull;
            else if (opCode == OpCodes.Ldobj) return SR::Emit.OpCodes.Ldobj;
            else if (opCode == OpCodes.Ldsfld) return SR::Emit.OpCodes.Ldsfld;
            else if (opCode == OpCodes.Ldsflda) return SR::Emit.OpCodes.Ldsflda;
            else if (opCode == OpCodes.Ldstr) return SR::Emit.OpCodes.Ldstr;
            else if (opCode == OpCodes.Ldtoken) return SR::Emit.OpCodes.Ldtoken;
            else if (opCode == OpCodes.Ldvirtftn) return SR::Emit.OpCodes.Ldvirtftn;
            else if (opCode == OpCodes.Leave) return SR::Emit.OpCodes.Leave;
            else if (opCode == OpCodes.Leave_S) return SR::Emit.OpCodes.Leave_S;
            else if (opCode == OpCodes.Localloc) return SR::Emit.OpCodes.Localloc;
            else if (opCode == OpCodes.Mkrefany) return SR::Emit.OpCodes.Mkrefany;
            else if (opCode == OpCodes.Mul) return SR::Emit.OpCodes.Mul;
            else if (opCode == OpCodes.Mul_Ovf) return SR::Emit.OpCodes.Mul_Ovf;
            else if (opCode == OpCodes.Mul_Ovf_Un) return SR::Emit.OpCodes.Mul_Ovf_Un;
            else if (opCode == OpCodes.Neg) return SR::Emit.OpCodes.Neg;
            else if (opCode == OpCodes.Newarr) return SR::Emit.OpCodes.Newarr;
            else if (opCode == OpCodes.Newobj) return SR::Emit.OpCodes.Newobj;
            else if (opCode == OpCodes.Nop) return SR::Emit.OpCodes.Nop;
            else if (opCode == OpCodes.Not) return SR::Emit.OpCodes.Not;
            else if (opCode == OpCodes.Or) return SR::Emit.OpCodes.Or;
            else if (opCode == OpCodes.Pop) return SR::Emit.OpCodes.Pop;
            else if (opCode == OpCodes.Readonly) return SR::Emit.OpCodes.Readonly;
            else if (opCode == OpCodes.Refanytype) return SR::Emit.OpCodes.Refanytype;
            else if (opCode == OpCodes.Refanyval) return SR::Emit.OpCodes.Refanyval;
            else if (opCode == OpCodes.Rem) return SR::Emit.OpCodes.Rem;
            else if (opCode == OpCodes.Rem_Un) return SR::Emit.OpCodes.Rem_Un;
            else if (opCode == OpCodes.Ret) return SR::Emit.OpCodes.Ret;
            else if (opCode == OpCodes.Rethrow) return SR::Emit.OpCodes.Rethrow;
            else if (opCode == OpCodes.Shl) return SR::Emit.OpCodes.Shl;
            else if (opCode == OpCodes.Shr) return SR::Emit.OpCodes.Shr;
            else if (opCode == OpCodes.Shr_Un) return SR::Emit.OpCodes.Shr_Un;
            else if (opCode == OpCodes.Sizeof) return SR::Emit.OpCodes.Sizeof;
            else if (opCode == OpCodes.Starg) return SR::Emit.OpCodes.Starg;
            else if (opCode == OpCodes.Starg_S) return SR::Emit.OpCodes.Starg_S;
            else if (opCode == OpCodes.Stelem) return SR::Emit.OpCodes.Stelem;
            else if (opCode == OpCodes.Stelem_I) return SR::Emit.OpCodes.Stelem_I;
            else if (opCode == OpCodes.Stelem_I1) return SR::Emit.OpCodes.Stelem_I1;
            else if (opCode == OpCodes.Stelem_I2) return SR::Emit.OpCodes.Stelem_I2;
            else if (opCode == OpCodes.Stelem_I4) return SR::Emit.OpCodes.Stelem_I4;
            else if (opCode == OpCodes.Stelem_I8) return SR::Emit.OpCodes.Stelem_I8;
            else if (opCode == OpCodes.Stelem_R4) return SR::Emit.OpCodes.Stelem_R4;
            else if (opCode == OpCodes.Stelem_R8) return SR::Emit.OpCodes.Stelem_R8;
            else if (opCode == OpCodes.Stelem_Ref) return SR::Emit.OpCodes.Stelem_Ref;
            else if (opCode == OpCodes.Stfld) return SR::Emit.OpCodes.Stfld;
            else if (opCode == OpCodes.Stind_I) return SR::Emit.OpCodes.Stind_I;
            else if (opCode == OpCodes.Stind_I1) return SR::Emit.OpCodes.Stind_I1;
            else if (opCode == OpCodes.Stind_I2) return SR::Emit.OpCodes.Stind_I2;
            else if (opCode == OpCodes.Stind_I4) return SR::Emit.OpCodes.Stind_I4;
            else if (opCode == OpCodes.Stind_I8) return SR::Emit.OpCodes.Stind_I8;
            else if (opCode == OpCodes.Stind_R4) return SR::Emit.OpCodes.Stind_R4;
            else if (opCode == OpCodes.Stind_R8) return SR::Emit.OpCodes.Stind_R8;
            else if (opCode == OpCodes.Stind_Ref) return SR::Emit.OpCodes.Stind_Ref;
            else if (opCode == OpCodes.Stloc) return SR::Emit.OpCodes.Stloc;
            else if (opCode == OpCodes.Stloc_0) return SR::Emit.OpCodes.Stloc_0;
            else if (opCode == OpCodes.Stloc_1) return SR::Emit.OpCodes.Stloc_1;
            else if (opCode == OpCodes.Stloc_2) return SR::Emit.OpCodes.Stloc_2;
            else if (opCode == OpCodes.Stloc_3) return SR::Emit.OpCodes.Stloc_3;
            else if (opCode == OpCodes.Stloc_S) return SR::Emit.OpCodes.Stloc_S;
            else if (opCode == OpCodes.Stobj) return SR::Emit.OpCodes.Stobj;
            else if (opCode == OpCodes.Stsfld) return SR::Emit.OpCodes.Stsfld;
            else if (opCode == OpCodes.Sub) return SR::Emit.OpCodes.Sub;
            else if (opCode == OpCodes.Sub_Ovf) return SR::Emit.OpCodes.Sub_Ovf;
            else if (opCode == OpCodes.Sub_Ovf_Un) return SR::Emit.OpCodes.Sub_Ovf_Un;
            else if (opCode == OpCodes.Switch) return SR::Emit.OpCodes.Switch;
            else if (opCode == OpCodes.Tailcall) return SR::Emit.OpCodes.Tailcall;
            else if (opCode == OpCodes.Throw) return SR::Emit.OpCodes.Throw;
            else if (opCode == OpCodes.Unaligned) return SR::Emit.OpCodes.Unaligned;
            else if (opCode == OpCodes.Unbox) return SR::Emit.OpCodes.Unbox;
            else if (opCode == OpCodes.Unbox_Any) return SR::Emit.OpCodes.Unbox_Any;
            else if (opCode == OpCodes.Volatile) return SR::Emit.OpCodes.Volatile;
            else if (opCode == OpCodes.Xor) return SR::Emit.OpCodes.Xor;

            throw new NotImplementedException();
        }
    }
}
