using System.Collections.Generic;

namespace TNEClient.Dtos
{
    public class ResponseResult
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }


        //public override string ToString()
        //{
        //    return $"BillingPointDto" +
        //        $"[ Id:{Id}, " +
        //        $"StartTime:{StartTime}, " +
        //        $"EndTime:{EndTime}, " +
        //        $"ControlPointId:{ControlPointId}, " +
        //        $"ControlPointName:{ControlPointName}, " +
        //        $"DeliveryPointId:{DeliveryPointId} " +
        //        $"DeliveryPointName:{DeliveryPointName} ]";
        //}
    }
}
