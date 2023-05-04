using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;

namespace Tax_Api.Bussines
{
    public class Utilities
    {
        /// <summary>
        /// Sign String
        /// </summary>
        /// <param name="stringToBeSigned"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string SignData(String stringToBeSigned, string
privateKey)
        {
            var pem = "-----BEGIN PRIVATE KEY-----\n" + privateKey + "\n-----END PRIVATE KEY---- - "; // Add header and footer
            PemReader pr = new PemReader(new StringReader(pem));
            AsymmetricKeyParameter privateKeyParams =
            (AsymmetricKeyParameter)pr.ReadObject();
            RSAParameters rsaParams =
            DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)privateKeyParams)
            ;
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters((RSAParameters)rsaParams);
            var dataBytes = Encoding.UTF8.GetBytes(stringToBeSigned);
            return Convert.ToBase64String(csp.SignData(dataBytes,
            HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));

        }
        public static string AesEncrypt(byte[] payload, byte[] key, byte[] iv)
        {
            var cipher = new GcmBlockCipher(new AesEngine());
            byte[] baPayload = new byte[0];
            cipher.Init(true, new AeadParameters(new KeyParameter(key), 128, iv,
           baPayload));
            var cipherBytes = new byte[cipher.GetOutputSize(payload.Length)];
            int len = cipher.ProcessBytes(payload, 0, payload.Length, cipherBytes, 0);
            cipher.DoFinal(cipherBytes, len);
            return Convert.ToBase64String(cipherBytes);
        }
        public static byte[] Xor(byte[] left, byte[] right)
        {/*from w w w. ja v a 2 s . c o m*/
            byte[] val = new byte[left.Length];
            for (int i = 0; i < left.Length; i++)
                val[i] = (byte)(left[i] ^ right[i]);
            return val;
        }
        /// <summary>
        /// one Time This Method Should CallTime Secret Key
        /// </summary>
        /// <param name="stringToBeEncrypted"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static string EncryptData(String stringToBeEncrypted, string
publicKey)
        {
            try
            {
                var pem = "-----BEGIN PUBLIC KEY-----\n" + publicKey + "\n-----END PUBLIC KEY-----"; // Add header and footer
                AsymmetricKeyParameter asymmetricKeyParameter =
    PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
                RsaKeyParameters rsaKeyParameters =
                (RsaKeyParameters)asymmetricKeyParameter;
                RSAParameters rsaParameters = new RSAParameters();
                rsaParameters.Modulus =
                rsaKeyParameters.Modulus.ToByteArrayUnsigned();
                rsaParameters.Exponent =
                rsaKeyParameters.Exponent.ToByteArrayUnsigned();
                RSACng rsa = new RSACng();
                rsa.ImportParameters(rsaParameters);
                string base64 =
                Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(stringToBeEncrypted
                ), RSAEncryptionPadding.OaepSHA256));
                if (base64.Length % 4 == 3)
                {
                    base64 += "=";
                }
                else if (base64.Length % 4 == 2)
                {
                    base64 += "==";
                }
                return base64;
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        public static byte[] GenerateRandomByteArray(int size)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[size];
                rng.GetBytes(buffer);
                return buffer;
            }
        }

    }
}
