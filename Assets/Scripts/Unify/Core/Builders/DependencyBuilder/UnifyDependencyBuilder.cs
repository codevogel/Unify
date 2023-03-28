using System;
using System.Collections.Generic;

namespace Unify.Core.Builders.DependencyBuilder
{
    public class UnifyDependencyBuilder<TDependency> : IDependencyBuilder<TDependency>
    {
        private readonly Dictionary<UnifyDependency, object> _dependencies;

        private bool _fromInstanceSatisfied = false;
        private bool _registerWasCalled = false;
        
        
        private TDependency _instance;
        private string _id;

        public UnifyDependencyBuilder(Dictionary<UnifyDependency, object> dependencies)
        {
            _dependencies = dependencies;
        }

        public IDependencyBuilder<TDependency> FromInstance(TDependency instance)
        {
            _instance = instance;
            _fromInstanceSatisfied = true;
            return this;
        }

        public IDependencyBuilder<TDependency> WithId(string id)
        {
            _id = id;
            return this;
        }

        public void Register()
        {
            _registerWasCalled = true;
            
            if (!_fromInstanceSatisfied)
                throw new Exception("Missing a call to FromInstance: A dependency builder received an attempt to Register before an instance was bound.");
            
            var dependency = new UnifyDependency(typeof(TDependency), _id);
            if (_dependencies.ContainsKey(dependency))
                throw new Exception($"Already contains a similar dependency: {dependency}");
            _dependencies[dependency] = _instance;
        }

        public void Dispose()
        {
            if (!_registerWasCalled)
                throw new Exception("Missing a call to Register: A dependency builder fell out of scope before an attempt to Register it was made!");
        }
    }
}