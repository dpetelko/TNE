using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNE.Models
{
    public class VoltageTransformer : Transformer
    {
        public override string ToString()
        {
            return $"VoltageTransformer" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"VerificationDate:{VerificationDate}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPoint:{ControlPoint} " +
                $"Status:{Status} ]";
        }
    }
}
