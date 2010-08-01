﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using MC = Mono.Cecil;

namespace Urasandesu.NAnonym.CREUtilities
{
    public static class TypeAnalyzer
    {
        public static bool IsAnonymous(MethodBase methodBase)
        {
            return methodBase.GetCustomAttributes(true).OfType<CompilerGeneratedAttribute>().FirstOrDefault() != null &&
                methodBase.Name.IndexOf("<") == 0;
        }

        public static bool IsCandidateAnonymousMethodCache(FieldInfo field)
        {
            return -1 < field.Name.IndexOf("__CachedAnonymousMethodDelegate") &&
                field.GetCustomAttributes(true).OfType<CompilerGeneratedAttribute>().FirstOrDefault() != null;
        }

        public static FieldInfo GetCacheFieldIfAnonymous(MethodBase methodBase)
        {
            if (!IsAnonymous(methodBase)) return null;


            var cacheField = default(FieldInfo);
            var declaringType = methodBase.DeclaringType;
            var declaringTypeDef = declaringType.ToTypeDef();

            var candidateNameCacheFieldDictionary = new Dictionary<string, FieldInfo>();
            foreach (var candidateCacheField in declaringType.GetFields(BindingFlags.NonPublic | BindingFlags.Static)
                                                             .Where(field => IsCandidateAnonymousMethodCache(field)))
            {
                candidateNameCacheFieldDictionary.Add(candidateCacheField.Name, candidateCacheField);
            }


            string declaringMethodName = methodBase.Name.Substring(methodBase.Name.IndexOf("<") + 1, methodBase.Name.IndexOf(">") - 1);
            foreach (var candidateMethod in declaringTypeDef.Methods.Where(method => -1 < method.Name.IndexOf(declaringMethodName)))
            {
                int candidatePoint = 0; // HACK: enum 化
                var candidateCacheField = default(FieldDefinition);
                foreach (var instruction in candidateMethod.Body.Instructions)
                {
                    if (candidatePoint == 0 &&
                        instruction.OpCode == MC.Cil.OpCodes.Ldsfld &&
                        candidateNameCacheFieldDictionary.ContainsKey((candidateCacheField = (FieldDefinition)instruction.Operand).Name))
                    {
                        candidatePoint = 1;
                    }
                    else if (candidatePoint == 1 &&
                        instruction.OpCode == MC.Cil.OpCodes.Brtrue_S)
                    {
                        candidatePoint = 2;
                    }
                    else if (candidatePoint == 2 &&
                        instruction.OpCode == MC.Cil.OpCodes.Ldnull)
                    {
                        candidatePoint = 3;
                    }
                    else if (candidatePoint == 3 &&
                        instruction.OpCode == MC.Cil.OpCodes.Ldftn &&
                        ((MethodReference)instruction.Operand).Equivalent(methodBase))
                    {
                        candidatePoint = 4;
                        break;
                    }
                    else if (candidatePoint == 3 || candidatePoint == 2 || candidatePoint == 1)
                    {
                        candidatePoint = 0;
                    }
                }
                if (candidatePoint == 4)
                {
                    cacheField = candidateNameCacheFieldDictionary[candidateCacheField.Name];
                    break;
                }
            }
            return cacheField;
        }
    }
}