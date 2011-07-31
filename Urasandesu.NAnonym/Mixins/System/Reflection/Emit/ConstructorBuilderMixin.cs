/* 
 * File: ConstructorBuilderMixin.cs
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
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using Urasandesu.NAnonym.ILTools.Impl.System.Reflection;
using Urasandesu.NAnonym.Mixins.Urasandesu.NAnonym.ILTools;
using Urasandesu.NAnonym.ILTools;

namespace Urasandesu.NAnonym.Mixins.System.Reflection.Emit
{
    public static class ConstructorBuilderMixin
    {
        public static void ExpressBody(this ConstructorBuilder constructorBuilder, Action<ReflectiveMethodDesigner2> expression)
        {
            var gen = new ReflectiveMethodDesigner2();
            var methodGen = new SRConstructorGeneratorImpl(constructorBuilder);
            gen.ILBuilder = new ILBuilder(methodGen, typeof(void).ToTypeDecl());
            expression(gen);
            gen.Eval(() => Dsl.End());
        }

        public static void ExpressBody(this ConstructorBuilder constructorBuilder, Action<ReflectiveMethodDesigner2> expression, FieldBuilder[] fieldBuilders)
        {
            var gen = new ReflectiveMethodDesigner2();
            var methodGen = new SRConstructorGeneratorImpl(constructorBuilder, fieldBuilders);
            gen.ILBuilder = new ILBuilder(methodGen, typeof(void).ToTypeDecl());
            expression(gen);
            gen.Eval(() => Dsl.End());
        }

        public static void ExpressBody(this ConstructorBuilder constructorBuilder, Action<ReflectiveMethodDesigner2> expression, ParameterBuilder[] parameterBuilders)
        {
            var gen = new ReflectiveMethodDesigner2();
            var methodGen = new SRConstructorGeneratorImpl(constructorBuilder, parameterBuilders);
            gen.ILBuilder = new ILBuilder(methodGen, typeof(void).ToTypeDecl());
            expression(gen);
            gen.Eval(() => Dsl.End());
        }

    }
}

