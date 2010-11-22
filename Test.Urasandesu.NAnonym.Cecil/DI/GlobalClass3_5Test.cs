﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Urasandesu.NAnonym.Cecil.DI;
using Test.Urasandesu.NAnonym.Etc;

namespace Test.Urasandesu.NAnonym.Cecil.DI
{
    [TestFixture]
    public class GlobalClass3_5Test
    {
        static GlobalClass3_5Test()
        {
            DependencyUtil.RollbackGlobal();

            DependencyUtil.RegisterGlobal<GlobalClass3_5>();
            DependencyUtil.LoadGlobal();
        }

        [Test]
        public void AddTest01()
        {
            var class3 = new Class3();

            Assert.AreEqual(2, class3.Add(1, 1));
            Assert.AreEqual(3, class3.Add(1, 1));
            Assert.AreEqual(4, class3.Add(1, 1));
        }
    }

    [TestFixture]
    public class GlobalClass3_6Test
    {
        static GlobalClass3_6Test()
        {
            DependencyUtil.RollbackGlobal();

            DependencyUtil.RegisterGlobal<GlobalClass3_6>();
            DependencyUtil.LoadGlobal();
        }

        [Test]
        public void AddTest01()
        {
            var class3 = new Class3();

            Assert.AreEqual(4, class3.Add(1, 1));
        }
    }
}
