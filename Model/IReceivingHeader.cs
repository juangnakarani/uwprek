using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwprek.Model
{
    public interface IReceivingHeader
    {
        void OnSuccessReceivingHeaders(List<ReceivingHeader> receivingHeaders);
    }
}
