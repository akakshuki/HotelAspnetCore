using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AppAdmin.Models.Common;
using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AppAdmin.Models.DAO
{
    public class OrderDao
    {
        private ApiService _api = null;
        private string url = "";
        public OrderDao() => _api = new ApiService();



    }
}
