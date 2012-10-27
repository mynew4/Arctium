/*
 * Copyright (C) 2012 Arctium <http://>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

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
