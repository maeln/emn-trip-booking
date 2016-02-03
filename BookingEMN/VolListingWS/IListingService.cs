using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VolListingWS
{
    [ServiceContract]
    public interface IListingService
    {

        [OperationContract]
        Flight[] getFlight(string departure, string arrival);

        [OperationContract]
        string[] getCities();
    }
}
