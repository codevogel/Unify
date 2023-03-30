using System;
using UnityEngine;

namespace Unify.Core.Builders.ObjectBuilder
{
    public class UnifyObjectBuilder<TObject> : IObjectBuilder<TObject>
    {

        private readonly Type[] _parameters;

        public UnifyObjectBuilder()
        {
            _parameters = new[] { typeof(TObject) };
        }
        public UnifyObjectBuilder(Type[] parameters)
        {
            _parameters = parameters;
        }
        
        public TObject Build(string name = default)
        {
            return new GameObject(name, _parameters).GetComponent<TObject>();
        }
    }
}