/* 
 * File: LocalOverrideMethodWeaveDefiner.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2010 Akira Sugiura
 *  
 *  This software is MIT License.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */
 

using System.Reflection;
using System.Reflection.Emit;
using Urasandesu.NAnonym.ILTools;
using Urasandesu.NAnonym.ILTools.Impl.System.Reflection;
using Urasandesu.NAnonym.Mixins.System.Reflection;

namespace Urasandesu.NAnonym.DW
{
    class LocalOverrideMethodWeaveDefiner : LocalMethodWeaveDefiner
    {
        public LocalOverrideMethodWeaveDefiner(MethodWeaver parent, WeaveMethodInfo injectionMethod)
            : base(parent, injectionMethod)
        {
        }

        protected override IMethodGenerator GetMethodInterface()
        {
            const MethodAttributes @override = MethodAttributes.Public |
                                               MethodAttributes.HideBySig |
                                               MethodAttributes.Virtual;
            var source = WeaveMethod.Source;
            var name = source.Name;
            var returnType = source.ReturnType;
            var parameterTypes = source.ParameterTypes();
            baseMethod = new SRMethodDeclarationImpl(source);
            return Parent.ConstructorWeaver.DeclaringTypeGenerator.AddMethod(
                name, @override, CallingConventions.HasThis, returnType, parameterTypes);
        }

        IMethodDeclaration baseMethod;
        public override IMethodDeclaration BaseMethod
        {
            get { return baseMethod; }
        }
    }
}
