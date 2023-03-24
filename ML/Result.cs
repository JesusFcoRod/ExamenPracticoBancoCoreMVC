﻿namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception{ get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }

    }
}