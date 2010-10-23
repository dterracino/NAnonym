﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Urasandesu.NAnonym.ILTools;
using SR = System.Reflection;
using SRE = System.Reflection.Emit;
using Urasandesu.NAnonym.Mixins.System.Reflection;
using Urasandesu.NAnonym.ILTools.Mixins.System;
using Urasandesu.NAnonym.ILTools.Mixins.System.Reflection.Emit;

namespace Urasandesu.NAnonym.DI
{
    class LocalImplementAnonymousInstanceMethodInjection : LocalAnonymousInstanceMethodInjection
    {
        public LocalImplementAnonymousInstanceMethodInjection(TypeBuilder tbaseTypeBuilder, TargetMethodInfo targetMethodInfo)
            : base(tbaseTypeBuilder, targetMethodInfo)
        {
        }

        public override void Apply(FieldBuilder cachedSettingBuilder, FieldBuilder cachedMethodBuilder)
        {
            var methodBuilder = localClassTypeBuilder.DefineMethod(
                                    targetMethodInfo.OldMethod.Name,
                                    MethodAttributes.Public |
                                    MethodAttributes.HideBySig |
                                    MethodAttributes.NewSlot |
                                    MethodAttributes.Virtual |
                                    MethodAttributes.Final,
                                    CallingConventions.HasThis,
                                    targetMethodInfo.OldMethod.ReturnType,
                                    targetMethodInfo.OldMethod.ParameterTypes());

            int parameterPosition = 1;
            var parameterBuilders = new List<ParameterBuilder>();
            foreach (var parameterName in targetMethodInfo.OldMethod.ParameterNames())
            {
                parameterBuilders.Add(methodBuilder.DefineParameter(parameterPosition++, ParameterAttributes.In, parameterName));
            }

            methodBuilder.ExpressBody(
            gen =>
            {
                var returnType = targetMethodInfo.OldMethod.ReturnType;
                var parameterTypes = targetMethodInfo.OldMethod.GetParameters().Select(parameter => parameter.ParameterType).ToArray();
                gen.Eval(_ => _.If(_.Ldfld(_.Extract(cachedMethodBuilder.Name, targetMethodInfo.DelegateType)) == null));
                {
                    var dynamicMethod = default(DynamicMethod);
                    gen.Eval(_ => _.Addloc(dynamicMethod, new DynamicMethod(
                                                                "dynamicMethod",
                                                                _.Expand(returnType),
                                                                new Type[] { _.Expand(localClassTypeBuilder) }.Concat(_.Expand(parameterTypes)).ToArray(),
                                                                _.Expand(localClassTypeBuilder),
                                                                true)));


                    var cacheField = default(FieldInfo);
                    gen.Eval(_ => _.Addloc(cacheField, _.Expand(localClassTypeBuilder).GetField(
                                                            _.Expand(cachedSettingBuilder.Name),
                                                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)));

                    var targetMethod = default(MethodInfo);
                    gen.Eval(_ => _.Addloc(targetMethod, _.Expand(targetMethodInfo.NewMethod.DeclaringType).GetMethod(
                                                            _.Expand(targetMethodInfo.NewMethod.Name),
                                                            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)));


                    var il = default(ILGenerator);
                    gen.Eval(_ => _.Addloc(il, dynamicMethod.GetILGenerator()));
                    gen.Eval(_ => il.Emit(SRE::OpCodes.Ldarg_0));
                    gen.Eval(_ => il.Emit(SRE::OpCodes.Ldfld, cacheField));
                    for (int parametersIndex = 0; parametersIndex < parameterTypes.Length; parametersIndex++)
                    {
                        switch (parametersIndex)
                        {
                            case 0:
                                gen.Eval(_ => il.Emit(SRE::OpCodes.Ldarg_1));
                                break;
                            case 1:
                                gen.Eval(_ => il.Emit(SRE::OpCodes.Ldarg_2));
                                break;
                            case 2:
                                gen.Eval(_ => il.Emit(SRE::OpCodes.Ldarg_3));
                                break;
                            case 3:
                                gen.Eval(_ => il.Emit(SRE::OpCodes.Ldarg, (short)4));
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                    }
                    gen.Eval(_ => il.Emit(SRE::OpCodes.Callvirt, targetMethod));
                    gen.Eval(_ => il.Emit(SRE::OpCodes.Ret));
                    gen.Eval(_ => _.Stfld(_.Extract(cachedMethodBuilder.Name, targetMethodInfo.DelegateType),
                                          _.Extract(targetMethodInfo.DelegateType),
                                          dynamicMethod.CreateDelegate(_.Expand(targetMethodInfo.DelegateType), _.This())));
                }
                gen.Eval(_ => _.EndIf());
                var invoke = targetMethodInfo.DelegateType.GetMethod(
                                                            "Invoke",
                                                            BindingFlags.Public | BindingFlags.Instance,
                                                            null,
                                                            parameterTypes,
                                                            null);
                gen.Eval(_ => _.Return(_.Invoke(_.Ldfld(_.Extract(cachedMethodBuilder.Name, targetMethodInfo.DelegateType)),
                                                _.Extract(invoke),
                                                _.Ldarg(_.Extract<object[]>(targetMethodInfo.OldMethod.ParameterNames())))));
            },
            parameterBuilders.ToArray(),
            new FieldBuilder[] { cachedMethodBuilder });
        }
    }
}
