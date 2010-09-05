﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using MC = Mono.Cecil;
using Mono.Cecil.Cil;
using System.Runtime.Serialization;

namespace Urasandesu.NAnonym.CREUtilities.Impl.Mono.Cecil
{
    [Serializable]
    class MCPortableScopeItemImpl : DeserializableManually, IPortableScopeItem
    {
        PortableScopeItemRawData itemRawData;

        [NonSerialized]
        internal FieldDefinition fieldDef;

        [NonSerialized]
        internal VariableDefinition variableDef;
        string variableTypeFullName;
        int variableIndex;

        public MCPortableScopeItemImpl(PortableScopeItemRawData itemRawData, FieldDefinition fieldDef, VariableDefinition variableDef)
            : this(itemRawData, default(object), fieldDef, variableDef)
        {
        }

        // NOTE: 構築中はこちら。まだ実体化してないので、GlobalAssemblyResolver.Resolve できない。
        public MCPortableScopeItemImpl(PortableScopeItemRawData itemRawData, object value, FieldDefinition fieldDef, VariableDefinition variableDef)
            : base(true)
        {
            this.itemRawData = itemRawData;
            variableTypeFullName = variableDef.VariableType.FullName;
            variableIndex = variableDef.Index;
            Value = value;
            Initialize(this, fieldDef, variableDef);
        }

        static void Initialize(MCPortableScopeItemImpl that, FieldDefinition fieldDef, VariableDefinition variableDef)
        {
            that.fieldDef = fieldDef;
            that.variableDef = variableDef; // MEMO: Index で取得できる範囲の変数は、構築時の名前が残っていないのかも。
        }

        public static explicit operator FieldDefinition(MCPortableScopeItemImpl scopeItem)
        {
            return scopeItem.fieldDef;
        }

        #region IPortableScopeItem メンバ

        public object Value { get; set; }

        public object Source
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return itemRawData.LocalName; }
        }

        #endregion

        #region ILocalDeclaration メンバ

        string ILocalDeclaration.Name
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IMemberDeclaration メンバ

        string IMemberDeclaration.Name
        {
            get { throw new NotImplementedException(); }
        }

        public ITypeDeclaration Type
        {
            get { throw new NotImplementedException(); }
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        #endregion


        //[OnDeserialized]
        //internal void OnDeserialized(StreamingContext context)
        //{
        //    if (!deserialized)
        //    {
        //        deserialized = true;
        //        throw new NotImplementedException();
        //    }
        //}

        //#region IDeserializationCallback メンバ

        //public void OnDeserialization(object sender)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        protected override void OnDeserializedManually(StreamingContext context)
        {
            //itemRawData.OnDeserialized(context);

            var methodDecl = default(IMethodBaseDeclaration);
            if ((methodDecl = context.Context as IMethodBaseDeclaration) != null)
            {
                var methodDef = (MethodDefinition)(MCMethodGeneratorImpl)methodDecl;
                var fieldDef = methodDef.DeclaringType.Fields.First(_fieldDef => _fieldDef.Name == itemRawData.FieldName);
                var variableDef = methodDef.Body.Variables.First(
                    _variableDef => _variableDef.VariableType.FullName == variableTypeFullName && _variableDef.Index == variableIndex);
                Initialize(this, fieldDef, variableDef);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
