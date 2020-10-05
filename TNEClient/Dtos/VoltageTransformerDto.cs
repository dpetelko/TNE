using System;

namespace TNEClient.Dtos
{
    public class VoltageTransformerDto : DeviceDto
    {
        public int TransformationRate { get; set; }
        public VoltageTransformerDto() { }
        

        public override string ToString()
        {
            return $"VoltageTransformerDto" +
                $"[ Id:{Id}, " +
                $"Number:{Number}, " +
                $"Type:{Type}, " +
                $"LastVerificationDate:{LastVerificationDate}, " +
                $"InterTestingPeriod:{InterTestingPeriod}, " +
                $"TransformationRate:{TransformationRate}, " +
                $"ControlPointId:{ControlPointId} " +
                $"ControlPointName:{ControlPointName} " +
                $"Status:{Status} ]";
        }
    }
}
