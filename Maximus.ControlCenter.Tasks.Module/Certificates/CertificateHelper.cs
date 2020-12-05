using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.ControlCenter.Tasks.Module.Certificates
{
  public enum CertificateType { SelfSigned, EndPoint, RootCA, IntermediateCA }

  class CertificateHelper
  {
    public static X509Store GetStore(string name_id_enum)
    {
      // enum as int
      if (int.TryParse(name_id_enum, out int storeIndex) && storeIndex >= 1 && storeIndex <= 8)
      {
        return new X509Store((StoreName)storeIndex, StoreLocation.LocalMachine);
      }
      // Enum by standard name
      else if (Enum.TryParse(name_id_enum, true, out StoreName storeName))
      {
        return new X509Store(storeName, StoreLocation.LocalMachine);
      }
      // no name => default to Personal/My
      else if (string.IsNullOrWhiteSpace(name_id_enum))
        return new X509Store(StoreName.My, StoreLocation.LocalMachine);
      else
        // custom name
        return new X509Store(name_id_enum, StoreLocation.LocalMachine);
    }

    public static CertificateType GetCertificateType(X509Certificate2 certificate)
    {
      if (certificate.Extensions == null)
      {
        // not CA cert at all
        if (certificate.Issuer == certificate.Subject)
          return CertificateType.SelfSigned;
        return CertificateType.EndPoint;
      }
      else
      {
        if (certificate.HasPrivateKey)
          return CertificateType.EndPoint;
        foreach (X509Extension extension in certificate.Extensions)
        {
          if (extension.GetType() == typeof(X509BasicConstraintsExtension))
          {
            // this is CA cert
            if (certificate.Issuer == certificate.Subject)
              return CertificateType.RootCA;
            return CertificateType.IntermediateCA;
          }
        }
        // not CA cert at the end
        if (certificate.Issuer == certificate.Subject)
          return CertificateType.SelfSigned;
        return CertificateType.EndPoint;
      }
    }

    // https://stackoverflow.com/questions/54991/generating-random-passwords, answer by CodesInChaos
    public static string GetRandomAlphanumericString(int length)
    {
      const string alphanumericCharacters =
          "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
          "abcdefghijklmnopqrstuvwxyz" +
          "0123456789" + "!@#$%^&*()_";
      return GetRandomString(length, alphanumericCharacters);
    }

    public static string GetRandomString(int length, IEnumerable<char> characterSet)
    {
      if (length < 0)
        throw new ArgumentException("length must not be negative", "length");
      if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
        throw new ArgumentException("length is too big", "length");
      if (characterSet == null)
        throw new ArgumentNullException("characterSet");
      var characterArray = characterSet.Distinct().ToArray();
      if (characterArray.Length == 0)
        throw new ArgumentException("characterSet must not be empty", "characterSet");

      var bytes = new byte[length * 8];
      new RNGCryptoServiceProvider().GetBytes(bytes);
      var result = new char[length];
      for (int i = 0; i < length; i++)
      {
        ulong value = BitConverter.ToUInt64(bytes, i * 8);
        result[i] = characterArray[value % (uint)characterArray.Length];
      }
      return new string(result);
    }
  }
}
