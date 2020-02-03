using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aws.Core.Interface
{
    public interface IAwsRequestSigner
    {
        Task<HttpRequestMessage> Sign(HttpRequestMessage request, string service, string region);
    }
}
