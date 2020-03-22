using System;
using System.Collections.Generic;
using System.Text;

namespace MomoConnector.DTO
{
    public class JsonString
    {
        public string PartnerCode { get; set; }
        public string PartnerRefId { get; set; }
        public string Amount { get; set; }
        public string PaymentCode { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
