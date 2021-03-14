using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETIID
{
    public class OfficeKey
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string LicenseKey { get; set; }
        public string UsedBy { get; set; }
        public string UsedOn { get; set; }
        public string CID { get; set; }
        public bool Good { get; set; }
        public bool Used { get; set; }
        public bool Printed { get; set; }
        public string OriginalFileName { get; set; }

    }
}
