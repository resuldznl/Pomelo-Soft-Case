using PomeloSoftCase.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Infrastructure.Concrete
{
    public class EncryptionManager : IEncryptionManager
    {

        private const string salt = "b14ca5898a4e4133bbce2ea2315a1916";
        public string HashCreate(string value)
        {
            var valueBytes = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(
                                     password: value,
                                     salt: System.Text.Encoding.UTF8.GetBytes(salt),
                                     prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512,
                                     iterationCount: 10000,
                                     numBytesRequested: 256 / 8);

            return System.Convert.ToBase64String(valueBytes);
        }
    }
}
