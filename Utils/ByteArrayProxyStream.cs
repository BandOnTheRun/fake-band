using System;
using System.Runtime.CompilerServices;

namespace FakeBand.Utils
{
    internal class ByteArrayProxyStream : ImageConversionStreamBase
    {
        private byte[] buffer;

        private int offset;

        private int length;

        private int position;

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                return (long)this.length;
            }
        }

        public override long Position
        {
            get
            {
                return (long)this.position;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public void SetBuffer(byte[] buffer, int offset, int length)
        {
            this.buffer = buffer;
            this.offset = offset;
            this.length = length;
            this.position = 0;
        }

        public void ForgetBuffer()
        {
            this.buffer = null;
        }

        public override int Read(byte[] argb32Array, int offset, int count)
        {
            throw new InvalidOperationException();
        }

        public override void Write(byte[] argb32Array, int offset, int count)
        {
            throw new InvalidOperationException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteByte(byte value)
        {
            byte[] arg_1F_0 = this.buffer;
            int arg_1D_0 = this.offset;
            int num = this.position;
            this.position = num + 1;
            arg_1F_0[arg_1D_0 + num] = value;
        }
    }
}
