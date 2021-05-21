using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCoreApi.Helper
{
    public static class StreamHelper
    {

        public static async Task<bool> WriteStringToFile(string fileName, string plainText, byte[] key, byte[] iv)
        {
            try
            {
                using (Rijndael algo = Rijndael.Create())
                {
                    algo.Key = key;
                    algo.IV = iv;
                    algo.Mode = CipherMode.CBC;
                    algo.Padding = PaddingMode.PKCS7;

                    // Create the streams used for encryption.
                    using (FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    // Create an encryptor to perform the stream transform.
                    using (ICryptoTransform encryptor = algo.CreateEncryptor())
                    using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        // Write all data to the stream.
                      await sw.WriteAsync(plainText);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public static async Task<bool> AppendStringToFile(string fileName, string plainText, byte[] key, byte[] iv)
        {
            try
            {
                using (Rijndael algo = Rijndael.Create())
                {
                    algo.Key = key;
                    // The IV is set below
                    algo.Mode = CipherMode.CBC;
                    algo.Padding = PaddingMode.PKCS7;

                    // Create the streams used for encryption.
                    using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        byte[] previous = null;
                        int previousLength = 0;

                        long length = file.Length;

                        // No check is done that the file is correct!
                        if (length != 0)
                        {
                            // The IV length is equal to the block length
                            byte[] block = new byte[iv.Length];

                            if (length >= iv.Length * 2)
                            {
                                // At least 2 blocks, take the penultimate block
                                // as the IV
                                file.Position = length - iv.Length * 2;
                                file.Read(block, 0, block.Length);
                                algo.IV = block;
                            }
                            else
                            {
                                // A single block present, use the IV given
                                file.Position = length - iv.Length;
                                algo.IV = iv;
                            }

                            // Read the last block
                            file.Read(block, 0, block.Length);

                            // And reposition at the beginning of the last block
                            file.Position = length - iv.Length;

                            // We use a MemoryStream because the CryptoStream
                            // will close the Stream at the end
                            using (var ms = new MemoryStream(block))
                            // Create a decrytor to perform the stream transform.
                            using (ICryptoTransform decryptor = algo.CreateDecryptor())
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                // Read all data from the stream. The decrypted last
                                // block can be long up to block length characters
                                // (so up to iv.Length) (this with AES + CBC)
                                previous = new byte[iv.Length];
                                previousLength = await cs.ReadAsync(previous, 0, previous.Length);
                            }
                        }
                        else
                        {
                            // Use the IV given
                            algo.IV = iv;
                        }

                        // Create an encryptor to perform the stream transform.
                        using (ICryptoTransform encryptor = algo.CreateEncryptor())
                        using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Rewrite the last block, if present. We even skip
                            // the case of block present but empty
                            if (previousLength != 0)
                            {
                                await cs.WriteAsync(previous, 0, previousLength);
                            }

                            // Write all data to the stream.
                            await sw.WriteAsync(plainText);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        //public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)
        //{
        //    byte[] encrypted;
        //    byte[] IV;

        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = Key;

        //        aesAlg.GenerateIV();
        //        IV = aesAlg.IV;

        //        aesAlg.Mode = CipherMode.CBC;

        //        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        // Create the streams used for encryption. 
        //        using (var msEncrypt = new MemoryStream())
        //        {
        //            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (var swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    //Write all data to the stream.
        //                    swEncrypt.Write(plainText);
        //                }
        //                encrypted = msEncrypt.ToArray();
        //            }
        //        }
        //    }

        //    var combinedIvCt = new byte[IV.Length + encrypted.Length];
        //    Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
        //    Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

        //    // Return the encrypted bytes from the memory stream. 
        //    return combinedIvCt;

        //}

        //public static string Encrypt(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}

        //public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        //{
        //    byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes(plainText);

        //    byte[] encrypted;
        //    // Create a new AesManaged.    
        //    using (AesManaged aes = new AesManaged())
        //    {
        //        // Create encryptor    
        //        ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
        //        // Create MemoryStream    
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            // Create crypto stream using the CryptoStream class. This class is the key to encryption    
        //            // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
        //            // to encrypt    
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        //            {
        //                // Create StreamWriter and write data to a stream    
        //                using (StreamWriter sw = new StreamWriter(cs))
        //                    sw.Write(rawPlaintext);
        //                encrypted = ms.ToArray();
        //            }
        //        }
        //    }
        //    // Return encrypted data    
        //    return encrypted;
        //}

        public static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        //public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        // {
        //     try
        //     {
        //         // create file stream
        //         using FileStream myStream = new FileStream(@"C:\csharp\encrypted.txt", FileMode.OpenOrCreate);

        //         // configure encryption key.  
        //         using Aes aes = Aes.Create();
        //         aes.Key = key;

        //         // store IV
        //         byte[] iv = aes.IV;
        //         myStream.Write(iv, 0, iv.Length);

        //         // encrypt filestream  
        //         using CryptoStream cryptStream = new CryptoStream(
        //             myStream,
        //             aes.CreateEncryptor(),
        //             CryptoStreamMode.Write);

        //         // write to filestream
        //         using StreamWriter sWriter = new StreamWriter(cryptStream);
        //         string plainText = "Welcome to the lab of MrNetTek!";
        //         sWriter.WriteLine(plainText);

        //         // done 
        //         Console.WriteLine("---SUCCESSFUL ENCRYPTION---\n");

        //     }
        //     catch
        //     {
        //         // error  
        //         Console.WriteLine("---ENCRYPTION FAILED---");
        //         throw;
        //     }

        //     //// Check arguments.
        //     //if (plainText == null || plainText.Length <= 0)
        //     //    throw new ArgumentNullException("plainText");
        //     //if (Key == null || Key.Length <= 0)
        //     //    throw new ArgumentNullException("Key");
        //     //if (IV == null || IV.Length <= 0)
        //     //    throw new ArgumentNullException("IV");
        //     //byte[] encrypted;

        //     //// Create an AesManaged object
        //     //// with the specified key and IV.
        //     //using (AesManaged aesAlg = new AesManaged())
        //     //{
        //     //    aesAlg.Key = Key;
        //     //    aesAlg.IV = IV;

        //     //    // Create an encryptor to perform the stream transform.
        //     //    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //     //    // Create the streams used for encryption.
        //     //    using (MemoryStream msEncrypt = new MemoryStream())
        //     //    {
        //     //        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //     //        {
        //     //            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //     //            {
        //     //                //Write all data to the stream.
        //     //                swEncrypt.Write(plainText);
        //     //            }
        //     //            encrypted = msEncrypt.ToArray();
        //     //        }
        //     //    }
        //     //}

        //     //// Return the encrypted bytes from the memory stream.
        //     //return encrypted;


        // }
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
