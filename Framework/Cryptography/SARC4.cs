using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct EVP_CTX
{
    IntPtr cipher;
    IntPtr Engine;
    int encrypt;
    int buflen;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    byte[] oiv;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    byte[] iv;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    byte[] buf;
    int num;
    IntPtr app_data;
    int key_len;
    uint flags;
    IntPtr cipher_data;
    int final_used;
    int block_mask;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    byte[] final;
}

[StructLayout(LayoutKind.Sequential)]
internal struct EVP_MD_CTX
{
    IntPtr digest;
    IntPtr Engine;
    uint flags;
    IntPtr md_data;
}

[StructLayout(LayoutKind.Sequential)]
internal struct HMAC_CTX
{
    IntPtr md;
    EVP_MD_CTX md_ctx;
    EVP_MD_CTX i_ctx;
    EVP_MD_CTX o_ctx;
    uint key_length;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    byte[] key;
}

namespace Framework.Cryptography
{
    public class SARC4 : IDisposable
    {
        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void EVP_CIPHER_CTX_init(ref EVP_CTX ctx);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void EVP_EncryptInit_ex(ref EVP_CTX ctx, IntPtr Cipher, IntPtr Engine, byte[] key, byte[] iv);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int EVP_CIPHER_CTX_set_key_length(ref EVP_CTX ctx, int keylen);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int EVP_CIPHER_CTX_cleanup(ref EVP_CTX ctx);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int EVP_EncryptUpdate(ref EVP_CTX ctx, [Out] byte[] outp, ref int outL, [In] byte[] inp, int inplen);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int EVP_EncryptFinal_ex(ref EVP_CTX ctx, [Out] byte[] output, ref int outL);

        [DllImport("Libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr EVP_rc4();

        EVP_CTX context;

        public SARC4()
        {
            context = new EVP_CTX();
            EVP_CIPHER_CTX_init(ref context);
            EVP_EncryptInit_ex(ref context, EVP_rc4(), IntPtr.Zero, null, null);
            EVP_CIPHER_CTX_set_key_length(ref context, 20);
        }

        public void Dispose()
        {
            EVP_CIPHER_CTX_cleanup(ref context);
        }

        public void PrepareKey(byte[] seed)
        {
            EVP_EncryptInit_ex(ref context, IntPtr.Zero, IntPtr.Zero, seed, null);
        }

        public void ProcessBuffer(byte[] data, int len)
        {
            int outLen = 0;
            EVP_EncryptUpdate(ref context, data, ref outLen, data, len);
            EVP_EncryptFinal_ex(ref context, data, ref outLen);
        }

        private byte[] mCryptBuffer = new byte[258];
    }
}
