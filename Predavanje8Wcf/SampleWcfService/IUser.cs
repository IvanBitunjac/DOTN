using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleWcfService
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        string WelcomeUser(string username);
        [OperationContract]
        bool AuthenticateUser(string username, string password);
    }
}
