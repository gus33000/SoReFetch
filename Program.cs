using CommandLine;
using System;

namespace SoReFetch
{
    internal static class Program
    {
        public class Options
        {
            [Option('c', "product-code", Required = false, HelpText = "Product Code.")]
            public string ProductCode { get; set; }

            [Option('t', "product-type", Required = true, HelpText = "Product Type.")]
            public string ProductType { get; set; }

            [Option('o', "operator-code", Required = false, HelpText = "Operator Code.")]
            public string OperatorCode { get; set; }

            [Option('r', "revision", Required = false, HelpText = "Revision (useful for getting older package versions).")]
            public string Revision { get; set; }

            [Option('f', "firmware-revision", Required = false, HelpText = "Phone Firmware Revision (useful only for changing what Test package you get for ENOSW/MMOS).")]
            public string FirmwareRevision { get; set; }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Software Repository (SoRe) Fetch Utility");
            Console.WriteLine("Copyright 2021 (c) Gustave Monce");
            Console.WriteLine();
            Console.WriteLine("This software uses code from the following open source projects released under the MIT license:");
            Console.WriteLine();
            Console.WriteLine("WPinternals - Copyright (c) 2018, Rene Lergner - wpinternals.net - @Heathcliff74xda");
            Console.WriteLine();
            Console.WriteLine("Please see 3RDPARTY.txt for more information");
            Console.WriteLine();

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       string foundType = string.Empty;
                       string ffu = string.Empty;
                       string enosw = string.Empty;
                       string[] emergency = Array.Empty<string>();

                       try
                       {
                           Console.WriteLine();
                           Console.WriteLine("Searching FFU");
                           Console.WriteLine();
                           ffu = LumiaDownloadModel.SearchFFU(o.ProductType, o.ProductCode, o.OperatorCode, out foundType, o.Revision);
                       }
                       catch (DetailedException ex)
                       {
                           Console.WriteLine("Error while searching FFU");
                           Console.WriteLine(ex.Message);
                           Console.WriteLine(ex.SubMessage);
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("Error while searching FFU");
                           Console.WriteLine(ex.Message);
                       }

                       try
                       {
                           Console.WriteLine();
                           Console.WriteLine("Searching ENOSW");
                           Console.WriteLine();
                           enosw = LumiaDownloadModel.SearchENOSW(o.ProductType, o.FirmwareRevision, o.Revision);
                       }
                       catch (DetailedException ex)
                       {
                           Console.WriteLine("Error while searching ENOSW");
                           Console.WriteLine(ex.Message);
                           Console.WriteLine(ex.SubMessage);
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("Error while searching ENOSW");
                           Console.WriteLine(ex.Message);
                       }

                       try
                       {
                           Console.WriteLine();
                           Console.WriteLine("Searching Emergency");
                           Console.WriteLine();
                           emergency = LumiaDownloadModel.SearchEmergencyFiles(o.ProductType);
                       }
                       catch (DetailedException ex)
                       {
                           Console.WriteLine("Error while searching Emergency");
                           Console.WriteLine(ex.Message);
                           Console.WriteLine(ex.SubMessage);
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("Error while searching Emergency");
                           Console.WriteLine(ex.Message);
                       }

                       Console.WriteLine();
                       Console.WriteLine("Results");
                       Console.WriteLine();

                       if (!string.IsNullOrEmpty(foundType))
                       {
                           Console.WriteLine("Product Type: " + foundType);
                           Console.WriteLine();
                       }

                       if (!string.IsNullOrEmpty(ffu))
                       {
                           Console.WriteLine("FFU: " + ffu);
                           Console.WriteLine();
                       }

                       if (!string.IsNullOrEmpty(enosw))
                       {
                           Console.WriteLine("ENOSW: " + enosw);
                           Console.WriteLine();
                       }

                       if (emergency != null)
                       {
                           for (int i = 0; i < emergency.Length; i++)
                           {
                               Console.WriteLine("Emergency[" + i + "]: " + emergency[i]);
                           }
                       }
                   });
        }
    }
}
