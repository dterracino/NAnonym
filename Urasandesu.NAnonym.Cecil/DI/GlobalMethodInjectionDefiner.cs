﻿using System;
using System.Linq;
using System.Reflection;
using Urasandesu.NAnonym.Cecil.ILTools.Impl.Mono.Cecil;
using Urasandesu.NAnonym.Cecil.Mixins.Mono.Cecil;
using Urasandesu.NAnonym.DI;
using SR = System.Reflection;
using TypeAnalyzer = Urasandesu.NAnonym.Cecil.ILTools.TypeAnalyzer;
using UNI = Urasandesu.NAnonym.ILTools;
using System.Collections.ObjectModel;

namespace Urasandesu.NAnonym.Cecil.DI
{
    abstract class GlobalMethodInjectionDefiner : MethodInjectionDefiner
    {
        public GlobalMethodInjectionDefiner(MethodInjection parent, InjectionMethodInfo injectionMethod)
            : base(parent, injectionMethod)
        {
            anonymousStaticMethodCache = TypeAnalyzer.GetCacheFieldIfAnonymousByDirective(injectionMethod.Destination);
        }

        public override void Create()
        {
            cachedMethod = Parent.ConstructorInjection.DeclaringTypeGenerator.AddField(
                                        GlobalClass.CacheFieldPrefix + "Method" + Parent.IncreaseMethodCacheSequence(),
                                        InjectionMethod.DelegateType, 
                                        SR::FieldAttributes.Private);

            var declaringTypeDef = ((MCTypeGeneratorImpl)Parent.ConstructorInjection.DeclaringTypeGenerator).TypeDef;
            cachedSetting = new MCFieldGeneratorImpl(declaringTypeDef.Fields.FirstOrDefault(
                fieldDef => fieldDef.FieldType.Resolve().GetFullName() == InjectionMethod.Destination.DeclaringType.FullName));

            methodInterface = GetMethodInterface();
        }

        readonly FieldInfo anonymousStaticMethodCache;
        public override FieldInfo AnonymousStaticMethodCache
        {
            get { return anonymousStaticMethodCache; }
        }

        public override ReadOnlyCollection<UNI::IParameterGenerator> MethodParameters
        {
            get { throw new NotImplementedException(); }
        }

        public override UNI::IMethodDeclaration BaseMethod
        {
            get { throw new NotImplementedException(); }
        }

        UNI::IFieldGenerator cachedMethod;
        public override UNI::IFieldGenerator CachedMethod
        {
            get { return cachedMethod; }
        }

        UNI::IFieldGenerator cachedSetting;
        public override UNI::IFieldGenerator CachedSetting
        {
            get { return cachedSetting; }
        }

        UNI::IMethodBaseGenerator methodInterface;
        public override UNI::IMethodBaseGenerator MethodInterface
        {
            get { return methodInterface; }
        }
    }
}
