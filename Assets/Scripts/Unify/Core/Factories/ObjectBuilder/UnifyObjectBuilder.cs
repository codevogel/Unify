using System;
using UnityEngine;

namespace Unify.Core.Factories.ObjectBuilder
{
    public class UnifyObjectBuilder : IObjectBuilder
    {

        private readonly Type[] _parameters;

        public UnifyObjectBuilder(Type[] parameters)
        {
            _parameters = parameters;
        }
        
        public T Build<T>(string name = default)
        {
            return new GameObject(name, _parameters).GetComponent<T>();
        }
    }
}