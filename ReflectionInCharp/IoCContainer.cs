using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionInCharp
{
    public  class IoCContainer
    {
        private Dictionary<Type , Type> _mapping = 
            new Dictionary<Type, Type>();

        MethodInfo _resolveMethod;
        public void Register<TType, TImplimentaion>()
        { 
            if(!_mapping.ContainsKey(typeof(TType)))
            {
                _mapping.Add(typeof(TType), typeof(TImplimentaion));
            }
        } 
        public void Register(Type type , Type implementation)
        { 
            if(!_mapping.ContainsKey(type))
            {
                _mapping.Add(type,implementation);
            }
        }


        public TContract Resolve<TContract>()
        {
           if(typeof(TContract).IsGenericType &&
                _mapping.ContainsKey(typeof(TContract).GetGenericTypeDefinition()))
            {
                var openImplementation = _mapping[typeof(TContract).GetGenericTypeDefinition()];
                //var closedImplementation = openImplementation
                //    .MakeGenericType(typeof(TContract).GenericTypeArguments);
                return Create<TContract>(openImplementation);
            }

            if (!_mapping.ContainsKey(typeof(TContract)))
            {
                throw new ArgumentException($"No registration found for {typeof(TContract)}");
            }

            return Create<TContract>(_mapping[typeof(TContract)]);
        }

        private TContract Create<TContract>(Type contract)
        {
            if(_resolveMethod ==  null)
            {
                _resolveMethod = typeof(IoCContainer).GetMethod("Resolve");
            }

            var constructorParamas = contract.GetConstructors()
                                  .OrderByDescending(c => c.GetParameters().Length)
                                  .FirstOrDefault()
                                  ?.GetParameters()
                                  .Select(p =>
                                  {
                                     var genricMethod = _resolveMethod.MakeGenericMethod(p.ParameterType);
                                     return genricMethod.Invoke(this, null);
                                  }).
                                  ToArray();

           return (TContract)Activator.CreateInstance(contract, constructorParamas);
        }
    }
}
