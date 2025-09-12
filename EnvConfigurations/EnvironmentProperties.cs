using System;

namespace NSENVSettings
{
    public class EnvironmentProperties
    {
        public string? browsername { get; set; }
        public string? url { get; set; }
        public string? testdata { get; set; }
        public double page_load_timeout { get; set; } = 30;  // default value
        public double implicit_timeout { get; set; } = 30;
    }
}