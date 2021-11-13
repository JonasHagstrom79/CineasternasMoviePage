using System;

namespace CMDb.Models
{
    public class ErrorViewModel
    {
        #region Properties
        public string RequestId { get; set; } 
        #endregion

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
