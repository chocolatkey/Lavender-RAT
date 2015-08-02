Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
''https://stackoverflow.com/questions/16420173/standard-library-for-aes-encryption-for-vb-net
Namespace Crypt
    Public Class Aes256Base64Encrypter
        Public Function Encrypt(ByVal plainText As String, ByVal secretKey As String) As String
            Dim encryptedPassword As String = Nothing
            Using outputStream As MemoryStream = New MemoryStream()
                Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
                Using cryptoStream As CryptoStream = New CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim inputBuffer() As Byte = Encoding.Unicode.GetBytes(plainText)
                    cryptoStream.Write(inputBuffer, 0, inputBuffer.Length)
                    cryptoStream.FlushFinalBlock()
                    encryptedPassword = Convert.ToBase64String(outputStream.ToArray())
                End Using
            End Using
            Return encryptedPassword
        End Function

        Public Function Decrypt(ByVal encryptedBytes As String, ByVal secretKey As String) As String
            Dim plainText As String = Nothing
            Using inputStream As MemoryStream = New MemoryStream(Convert.FromBase64String(encryptedBytes))
                Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
                Using cryptoStream As CryptoStream = New CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read)
                    Dim outputBuffer(0 To CType(inputStream.Length - 1, Integer)) As Byte
                    Dim readBytes As Integer = cryptoStream.Read(outputBuffer, 0, CType(inputStream.Length, Integer))
                    plainText = Encoding.Unicode.GetString(outputBuffer, 0, readBytes)
                End Using
            End Using
            Return plainText
        End Function

        Public Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged
            Const salt As String = "lavender"
            Const keySize As Integer = 256

            Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt))
            Dim algorithm As RijndaelManaged = New RijndaelManaged()
            algorithm.KeySize = keySize
            algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
            algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
            algorithm.Padding = PaddingMode.PKCS7
            Return algorithm
        End Function
    End Class
End Namespace