using Jose;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace jwt_csharp_netcore
{
    class Program
    {
		
		/*
         * 
         * jwt-csharp.
         * Usage:
         * jwt-csharp.exe [--key=<str>] [--issuer=<str>] [--username=<str>]
         * jwt-csharp.exe (-h | --help)
         * Options:
         *  --key=<str>       path to private key
         *  --issuer=<str>    issuer id from api connsole
         *  --username=<str>  username if generating user token
         *  --expire=<int>  exprire time by seconds default = 1800"
         *  -h --help         Show this screen.
         *
         */
		 
        static void Main(string[] args)
        {            
            ParamOptions _paramOptions = new ParamOptions(args);
            _paramOptions.LoadArguments();
            try
            {

                if (_paramOptions.PrivateKeyPath != string.Empty)
                {

                    long currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();




                    int expire = _paramOptions.ExpireTime;

                    var payload = new Dictionary<string, object>();
                    payload["iss"] = _paramOptions.Issuer;
                    payload["iat"] = currentTime;

                    payload["exp"] = currentTime + expire; // default 1800s

                    if (_paramOptions.Username != string.Empty)
                    {
                        payload["sub"] = _paramOptions.Username;
                    }




                    string token = CreateToken(payload, _paramOptions.PrivateKeyPath);

                    Console.WriteLine("Token JWT:");
                    Console.WriteLine(token);
                }
                else
                {
                    Console.WriteLine("Path private key do not exist!");
                }


            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        private static string getKey(string pathKey)
        {
            string text = File.ReadAllText(pathKey, Encoding.UTF8);
            return text;
        }


        public static string CreateToken(Dictionary<string, object> payload, string privateRsaKeyPath)
        {
            RSAParameters rsaParams;
            using (var tr = new StreamReader(privateRsaKeyPath))
            {
                var pemReader = new PemReader(tr);

                RsaPrivateCrtKeyParameters privkey = null;
                Object obj = pemReader.ReadObject();
                if (obj != null)
                {
                    privkey = (RsaPrivateCrtKeyParameters)obj;
                }
                rsaParams = DotNetUtilities.ToRSAParameters(privkey);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                return Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS512);
            }
        }


    }
}
