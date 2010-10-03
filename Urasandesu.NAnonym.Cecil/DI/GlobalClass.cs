﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Urasandesu.NAnonym.ILTools;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Urasandesu.NAnonym.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SR = System.Reflection;
using MC = Mono.Cecil;
using Urasandesu.NAnonym.Cecil.ILTools;
using TypeAnalyzer = Urasandesu.NAnonym.Cecil.ILTools.TypeAnalyzer;
using Urasandesu.NAnonym.DI;
using Urasandesu.NAnonym.ILTools.Mixins.System;

namespace Urasandesu.NAnonym.Cecil.DI
{
    // MEMO: GlobalClass が Generic Type 持っちゃうから、共通で引き回せるような口用。
    public abstract class GlobalClass : MarshalByRefObject
    {
        GlobalClass modified;

        internal void Register()
        {
            modified = OnRegister();
            if (modified != null)
            {
                modified.Register();
            }
        }

        protected virtual GlobalClass OnRegister()
        {
            return null;
        }

        internal void Load()
        {
            OnLoad(modified);
            if (modified != null)
            {
                modified.Load();
            }
        }

        protected virtual void OnLoad(GlobalClass modified)
        {
        }

        protected internal abstract string CodeBase { get; }
        protected internal abstract string Location { get; }
    }

    public class GlobalClass<TBase> : GlobalClass
    {
        internal HashSet<TargetInfo> TargetInfoSet { get; private set; }

        public GlobalClass()
        {
            TargetInfoSet = new HashSet<TargetInfo>();
        }

        Action<GlobalClass<TBase>> setupper;
        public void Setup(Action<GlobalClass<TBase>> setupper)
        {
            this.setupper = Required.NotDefault(setupper, () => setupper);
        }

        protected override GlobalClass OnRegister()
        {
            setupper(this);
            return null;
        }

        //public GlobalMethod<TBase, T, TResult> Method<T, TResult>(Func<T, TResult> func)
        //{
        //    return new GlobalMethod<TBase, T, TResult>(this, func);
        //}

        public GlobalMethod<TBase, T, TResult> Method<T, TResult>(Expression<FuncReference<TBase, T, TResult>> expression)
        {
            var method = DependencyUtil.ExtractMethod(expression);
            var oldMethod = typeof(TBase).GetMethod(method);
            return new GlobalMethod<TBase, T, TResult>(this, oldMethod);
        }

        //protected override GlobalClassBase OnRegister()
        //{
        //    // Setup(Action<GlobalClass<TBase>>) で大方済んでるので、特にここでなにかやる必要は無さそう。
        //    return null;
        //}




        protected override void OnLoad(GlobalClass modified)
        {
            // MEMO: ここで modified に来るのは、OnSetup() の戻り値なので、ここでは特に使う必要はない。
            var tbaseModuleDef = ModuleDefinition.ReadModule(new Uri(typeof(TBase).Assembly.CodeBase).LocalPath, new ReaderParameters() { ReadSymbols = true });
            var tbaseTypeDef = tbaseModuleDef.GetType(typeof(TBase).FullName);

            var CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCache = default(Func<string, string>);
            var CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCacheDef =
                new FieldDefinition(TypeSavable.GetName(
                    () => CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCache),
                    MC::FieldAttributes.Private,
                    tbaseModuleDef.Import(typeof(Func<string, string>)));
            tbaseTypeDef.Fields.Add(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCacheDef);

            foreach (var targetInfo in TargetInfoSet)
            {
                switch (targetInfo.Mode)
                {
                    case SetupMode.Override:
                        throw new NotImplementedException();
                    case SetupMode.Replace:
                        {
                            var sourceMethodDef = tbaseTypeDef.Methods.FirstOrDefault(_methodDef => _methodDef.Equivalent(targetInfo.OldMethod));
                            string souceMethodName = sourceMethodDef.Name;
                            sourceMethodDef.Name = "__" + sourceMethodDef.Name;

                            // 元のメソッドと同じメソッドを追加（処理の中身は空にする）
                            var newMethod = sourceMethodDef.DuplicateWithoutBody();
                            newMethod.Name = souceMethodName;
                            tbaseTypeDef.Methods.Add(newMethod);

                            var tmpCacheField = TypeAnalyzer.GetCacheFieldIfAnonymousByDirective(targetInfo.NewMethod);
                            newMethod.Body.InitLocals = true;
                            newMethod.ExpressBody(
                            gen =>
                            {
                                gen.Eval(_ => _.If(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCache == null));
                                var CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method = default(DynamicMethod);
                                gen.Eval(_ => _.Addloc(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method, new DynamicMethod("CS$<>9__CachedAnonymousMethodDelegate1Method", typeof(string), new Type[] { typeof(string) }, true)));
                                var ctor3 = default(ConstructorInfo);
                                gen.Eval(_ => _.Addloc(ctor3, typeof(System.Func<,>).MakeGenericType(typeof(String), typeof(String)).GetConstructor(
                                                                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                    null,
                                                                    new Type[] 
                                                                    { 
                                                                        typeof(Object), 
                                                                        typeof(IntPtr) 
                                                                    }, null)));
                                var method4 = default(MethodInfo);
                                gen.Eval(_ => _.Addloc(method4, typeof(System.Func<,>).MakeGenericType(typeof(String), typeof(String)).GetMethod(
                                                                    "Invoke",
                                                                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                    null,
                                                                    new Type[] 
                                                                    { 
                                                                        typeof(String) 
                                                                    }, null)));
                                var cacheField = default(FieldInfo);
                                gen.Eval(_ => _.Addloc(cacheField, Type.GetType(_.Expand(tmpCacheField.DeclaringType.AssemblyQualifiedName)).GetField(
                                                                    _.Expand(tmpCacheField.Name),
                                                                    BindingFlags.NonPublic | BindingFlags.Static)));
                                var targetMethod = default(MethodInfo);
                                gen.Eval(_ => _.Addloc(targetMethod, Type.GetType(_.Expand(targetInfo.NewMethod.DeclaringType.AssemblyQualifiedName)).GetMethod(
                                                                    _.Expand(targetInfo.NewMethod.Name),
                                                                    BindingFlags.NonPublic | BindingFlags.Static)));
                                var il = default(ILGenerator);
                                gen.Eval(_ => _.Addloc(il, CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method.GetILGenerator()));
                                var label27 = default(Label);
                                gen.Eval(_ => _.Addloc(label27, il.DefineLabel()));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldsfld, cacheField));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Brtrue_S, label27));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldnull));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldftn, targetMethod));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Newobj, ctor3));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Stsfld, cacheField));
                                gen.Eval(_ => il.MarkLabel(label27));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldsfld, cacheField));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldarg_0));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Callvirt, method4));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ret));
                                gen.Eval(_ => _.Stfld(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCache, (Func<string, string>)CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method.CreateDelegate(typeof(Func<string, string>))));
                                gen.Eval(_ => _.EndIf());
                                gen.Eval(_ => _.Return(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1MethodCache.Invoke(_.ExpandAndLdarg<string>(targetInfo.NewMethod.GetParameters()[0].Name))));

                                // HACK: Expand ～ シリーズはもう少し種類があると良さげ。
                            });

                        }
                        break;
                    case SetupMode.Implement:
                        throw new NotImplementedException();
                    default:
                        throw new NotSupportedException();
                }
            }

            tbaseModuleDef.Write(new Uri(typeof(TBase).Assembly.CodeBase).LocalPath, new WriterParameters() { WriteSymbols = true });
        }

        protected internal override string CodeBase
        {
            get { return typeof(TBase).Assembly.CodeBase; }
        }

        protected internal override string Location
        {
            get { return typeof(TBase).Assembly.Location; }
        }
    }
}
