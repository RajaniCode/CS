using System;

namespace Gigya.Process.Model
{
    public class UserSignatureValidationResult
    {
        public string UID { set; get; }

        // public string UIDSignature { set; get; }

        // public string SignatureTimestamp { set; get; }

        public int StatusCode { set; get; }

        public int ErrorCode { set; get; }

        public string StatusReason { set; get; }

        public string CallId { set; get; }

        public DateTime Time { set; get; }

        public bool IsLoggedIn { get; internal set; }
    }
}
