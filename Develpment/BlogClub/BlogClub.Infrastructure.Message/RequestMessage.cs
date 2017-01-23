using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogClub.Infrastructure.Message
{
    public abstract class RequestMessage
    {
        public RequestMessage()
        {
            Header = new RequestHeader
            {

            };
        }
        public RequestHeader Header { get; set; }
    }
    /// <summary>
    /// 消息请求头
    /// </summary>
    public class RequestHeader
    {
        /// <summary>
        /// 渠道
        /// </summary>
        public String Channel { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public long Operator { get; set; }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public String IP { get; set; }
    }
}
