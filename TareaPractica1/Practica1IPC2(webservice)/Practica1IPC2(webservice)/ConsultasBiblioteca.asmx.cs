using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace Practica1IPC2_webservice_
{
    /// <summary>
    /// Summary description for ConsultasBiblioteca
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultasBiblioteca : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetContact(string id)
        {
            var json = "";
            var contact = "randy";

            JavaScriptSerializer jss = new JavaScriptSerializer();
            json = jss.Serialize(contact);
            

            return json;
        }

    }
}
