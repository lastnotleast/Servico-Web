using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Email
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public string EmailFrom { get; set; }

        public string SenhaFrom { get; set; }

        public string AwsAccessKeyId;

        public string AwsSecretAccessKey;

        public string AwsAccessKeyIdSMTP;

        public string AwsSecretAccessKeySMTP;
    }
}
