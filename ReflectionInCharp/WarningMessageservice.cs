using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ReflectionInCharp
{
   
    public class WarningMessageservice
    {
        private  NetworkMonitorSettings _monitorSettings;
        private  MethodInfo _warningMethodOnfo;
        private Type _warningType;


        public WarningMessageservice()
        {
            _monitorSettings =  new NetworkMonitorSettings();
            BootStrapFromConfiguration();
        }


       public  void DemoMonitoringNetworkExample()
        {
            Console.WriteLine("Monitoring network... something went wrong.");
            Warn();
        }


        void Warn()
        {
            var WarnservceInstance = Activator.CreateInstance(_warningType);

            var paramlist = _monitorSettings.PropertyBag.Values.ToArray();
            _warningMethodOnfo.Invoke(WarnservceInstance, paramlist);

        }


        private void BootStrapFromConfiguration()
        {
            var ConfigBuilder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", false, true)
                                  .Build();
            ConfigBuilder.Bind("NetworkMonitorSettings", _monitorSettings);

             _warningType = Assembly.GetExecutingAssembly()
                                    .GetType(_monitorSettings.WarningService);

            if (_warningType == null)
            {
                throw new Exception("Configuration is invalid - warning service not found");
            }

            _warningMethodOnfo =  _warningType.GetMethod(_monitorSettings.MethodToExecute);

            if (_warningMethodOnfo == null)
            {
                throw new Exception("Configuration is invalid - method to execute " +
                    "on warning service not found");
            }

            foreach (var parameterInfo in _warningMethodOnfo.GetParameters())
            {
                if (!_monitorSettings.PropertyBag.TryGetValue(
                    parameterInfo.Name, out object paramvalue))
                {
                    throw new Exception($"Configuration is invalid - parameter " +
                                $"{parameterInfo.Name} not found.");
                }

                try
                {
                    Convert.ChangeType(paramvalue, parameterInfo.ParameterType);
                }
                catch
                {
                    throw new Exception($"Configuration is invalid - parameter {parameterInfo.Name} " +
                              $"cannot be converted to expected type {parameterInfo.ParameterType}.");
                }

            }


        }


    }

    public class MailService
    {
        public void SendMail(string address, string subject)
        {
            Console.WriteLine($"Sending a warning mail to {address} with subject {subject}.");
        }
    }


    public class SoundHornService
    {
        public void SoundHorn(string volume)
        {
            Console.WriteLine($"Making noise with the volume turned up to {volume}.");
        }
    }
}
