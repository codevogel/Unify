using System;
using System.Collections.Generic;
using Unify.Core.Builders.DependencyBuilder;
using Unify.Core.Factories;

namespace Unify.Core
{
    public class UnifyContainer : IUnifyContainer
    {
        private Dictionary<UnifyDependency, object> _localDependencies = new ();

        public UnifyDependencyBuilder<TDependency> RegisterDependency<TDependency>()
        {
            return new UnifyDependencyBuilder<TDependency>(_localDependencies);
        }

        public object ResolveDependency(Type type, string id = default)
        {
            var dependency = new UnifyDependency(type, id);
            if (_localDependencies.ContainsKey(dependency))
            {
                return _localDependencies[dependency];
            }
            throw new Exception($"Cannot find a dependency with this key with type {type + (id == default ? "" : $"id {id}")}!");
        }


        public void RegisterDependenciesAndFactoriesFrom(UnifyContainer otherContainer)
        {
            // Register dependencies
            var dependenciesInOtherContainer = otherContainer._localDependencies;
            foreach (var dependencyObjectPair in dependenciesInOtherContainer)
            {
                if (dependencyObjectPair.Value is IObjectFactory factory)
                    factory.RegisterRootContainer(this);
                if (_localDependencies.ContainsKey(dependencyObjectPair.Key))
                    throw new Exception($"Already contains a dependency with key {dependencyObjectPair.Key}");
                _localDependencies[dependencyObjectPair.Key] = dependencyObjectPair.Value;
            }
        }

    }
}