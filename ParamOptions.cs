using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwt_csharp_netcore
{
    public class ParamOptions
    {         

        private string[] args;
        private StringBuilder _builderHelp = new StringBuilder();
        public ParamOptions() { }
        public ParamOptions(string[] _args) {
            args = _args;
            _builderHelp.AppendLine("* jwt-csharp.");
            _builderHelp.AppendLine("* Usage:");
            _builderHelp.AppendLine("* jwt-csharp.exe[--key =< str >][--issuer =< str >][--username =< str >]");
            _builderHelp.AppendLine("* jwt-csharp.exe(-h | --help)");
            _builderHelp.AppendLine("* Options:");
            _builderHelp.AppendLine("*  --key=<str>       path to private key");
            _builderHelp.AppendLine("*  --issuer_id=<str>    issuer id from api connsole");
            _builderHelp.AppendLine("*  --username=<str>  username if generating user token");            
            _builderHelp.AppendLine("*  -h --help Show this screen.");
        }

        //List<string> Param_Header = new List<string>() { "--key", "--issuer_id", "--username", "--expire", "-h" };
        List<string> Param_Header = new List<string>() { "--key", "--issuer_id", "--username", "-h" };

        public void PrintHelp()
        {
            Console.WriteLine(_builderHelp.ToString());
        }

        public void LoadArguments()
        {
            try {

                if(args.Length == 0)
                {
                    PrintHelp();
                }
                else
                {
                    foreach(string arg in args)
                    {
                        string[] params_arr = arg.Split(new string[] { "=" }, StringSplitOptions.None);
                        if(params_arr.Length == 2)
                        {
                            string _arg = params_arr[0]; //get header params
                            if (_arg.Contains("--key"))
                            {
                                PrivateKeyPath = params_arr[1];

                            }
                            if (_arg.Contains("--issuer_id"))
                            {
                                Issuer = params_arr[1];
                            }

                            if (_arg.Contains("--username"))
                            {
                                Username = params_arr[1];
                            }

                            //if (_arg.Contains("--expire"))
                            //{
                            //    ExpireTime = Convert.ToInt32(params_arr[1]);
                            //}
                        }
                        else
                        {
                            if(params_arr[0].ToLower() == "-h")
                            {
                                PrintHelp();
                            }
                        }
                       
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }

        public string PrivateKeyPath { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public int ExpireTime { get; set; } = 1800;

    }
}
