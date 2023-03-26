﻿using System;
using System.Linq;
using System.Reflection;
using Unify.Core.Attributes;
using Unify.Core.Factories.ObjectBuilder;
using UnityEngine;

namespace Unify.Core.Factories
{
    public abstract class BaseUnifyObjectFactory<TObject> : IObjectFactory
    {
        protected IUnifyContainer RootContainer;
        private readonly Action<TObject> _afterInstantiation;
        private readonly UnifyObjectBuilder<TObject> _objectBuilder;
        
        protected BaseUnifyObjectFactory()
        {
            _objectBuilder = new UnifyObjectBuilder<TObject>();
            _afterInstantiation = default;
        }

        protected BaseUnifyObjectFactory(Action<TObject> afterInstantiation)
        {
            _objectBuilder = new UnifyObjectBuilder<TObject>();
            _afterInstantiation = afterInstantiation;
        }

        public void RegisterRootContainer(IUnifyContainer rootContainer)
        {
            RootContainer = rootContainer;
        }

        private TObject CreateFromBuilder (string name = default)
        {
            return _objectBuilder.Build(name);
        }

        /// <summary>
        /// Override to manually handle injections into TObject o
        /// </summary>
        /// <param name="o">The object to inject dependencies into.</param>
        protected abstract void InjectDependenciesInto(TObject o);



        
        public TObject Create(
            string name = default,
            DependencyOverride dependencyOverride = null,
            Action<TObject> afterInstantiationOverride = default)
        {
            // Create object
            var o = CreateFromBuilder(name);
         
            // Inject dependencies
            if (dependencyOverride != null)
                OverrideInjection(o, dependencyOverride);
            else
                InjectDependenciesInto(o);

            // Invoke after instantiation action
            if (afterInstantiationOverride != null)
            {
                afterInstantiationOverride.Invoke(o);
                return o;
            }
            _afterInstantiation?.Invoke(o);
            return o;
        }
        
        public TObject Create(DependencyOverride dependencyOverride, string name = default)
        {
            return Create(name, dependencyOverride);
        }
        
        public TObject Create(Action<TObject> afterInstantiationOverride, string name = default)
        {
            return Create(name, default, afterInstantiationOverride);
        }

        private void OverrideInjection(TObject o, DependencyOverride dependencyOverride)
        {
            // Grab the method that has a `[FactoryOverride]` attribute with `FactoryOverride.ID == dependencyOverride.ID`
            var correspondingMethod = this
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m => m.GetCustomAttributes(typeof(FactoryOverrideAttribute), true)
                    .Any(a => ((FactoryOverrideAttribute)a).ID == dependencyOverride.ID));
            if (correspondingMethod == null)
                throw new Exception(
                    $"Could not find a corresponding method for the given dependencyOverride with id {dependencyOverride.ID}");

            // Invoke with custom parameters
            var parameters = dependencyOverride.CustomParameters.ToList();
            parameters.Insert(0, o);
            correspondingMethod.Invoke(this, parameters.ToArray());
        }
    }
    
}