using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.Text;

namespace Sop.Common.Img
{
    public class ReturnValues
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 帧个数
        /// </summary>
        public int FrameCount { get; set; }
        /// <summary>
        /// delay in milliseconds
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Size FrameSize { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> OutputFilePaths { get; set; }
    }
}
