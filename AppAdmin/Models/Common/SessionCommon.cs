using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AppAdmin.Models.Common
{
    public class SessionCommon
    {
        private ISession _session;

        private string accept_key_Order = "Order_Detail";

      
        public SessionCommon(HttpContext context)
        {
            _session = context.Session;
        }


        public string DataGet()
        {
            var data = _session.GetString(accept_key_Order);
            return data;
        }


        public void DataSet(string data)
        {
          _session.SetString(accept_key_Order, data);
        }

        public void dataRemove()
        {
            _session.Clear();
        }
    }
}
