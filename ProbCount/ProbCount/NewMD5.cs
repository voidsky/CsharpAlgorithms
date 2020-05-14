using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Count
{
    public class HashVal : IHashValue
    {
        public int BitLength => throw new NotImplementedException();

        public byte[] Hash { get; set; }

        public string AsBase64String()
        {
            return Convert.ToBase64String(Hash);
        }

        public BitArray AsBitArray()
        {
            throw new NotImplementedException();
        }

        public string AsHexString()
        {
            throw new NotImplementedException();
        }

        public string AsHexString(bool uppercase)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IHashValue other)
        {
            throw new NotImplementedException();
        }
    }

    public class NewMD5 : IHashFunction
    {
        public int HashSizeInBits => throw new NotImplementedException();

        public IHashValue ComputeHash(byte[] data)
        {
            HashAlgorithm hashFunction = new MD5CryptoServiceProvider();
            HashVal hv = new HashVal();
            hv.Hash = hashFunction.ComputeHash(data);
            return hv;
        }

        public IHashValue ComputeHash(byte[] data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IHashValue ComputeHash(Stream data)
        {
            throw new NotImplementedException();
        }

        public IHashValue ComputeHash(Stream data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class NewSHA1 : IHashFunction
    {
        public int HashSizeInBits => throw new NotImplementedException();

        public IHashValue ComputeHash(byte[] data)
        {
            HashAlgorithm hashFunction = new SHA1CryptoServiceProvider();
            HashVal hv = new HashVal();
            hv.Hash = hashFunction.ComputeHash(data);
            return hv;
        }

        public IHashValue ComputeHash(byte[] data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IHashValue ComputeHash(Stream data)
        {
            throw new NotImplementedException();
        }

        public IHashValue ComputeHash(Stream data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
