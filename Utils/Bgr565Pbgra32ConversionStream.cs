using System;
using System.IO;

namespace FakeBand.Utils
{
    internal class Bgr565Pbgra32ConversionStream : ImageConversionStreamBase
    {
        private const int pixelWidthFactor = 2;

        private int argb32Index;

        private ByteArrayProxyStream writeProxy;

        public override long Length
        {
            get
            {
                return (long)(this.Bgr565Array.Length * 2);
            }
        }

        public override long Position
        {
            get
            {
                return (long)this.argb32Index;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public byte[] Bgr565Array
        {
            get;
            private set;
        }

        public Bgr565Pbgra32ConversionStream(int argb32ByteCount)
        {
            this.Bgr565Array = new byte[argb32ByteCount / 2];
        }

        public Bgr565Pbgra32ConversionStream(byte[] bgr565Array)
        {
            this.Bgr565Array = bgr565Array;
        }

        public override int Read(byte[] argb32Array, int offset, int count)
        {
            if (this.writeProxy == null)
            {
                this.writeProxy = new ByteArrayProxyStream();
            }
            this.writeProxy.SetBuffer(argb32Array, offset, count);
            try
            {
                this.CopyToInternal(writeProxy, count);
            }
            finally
            {
                this.writeProxy.ForgetBuffer();
            }
            return count;
        }

        public override void Write(byte[] argb32Array, int offset, int count)
        {
            int num = this.argb32Index / 2;
            while ((long)this.argb32Index < this.Length && count > 0)
            {
                switch (this.argb32Index % 4)
                {
                    case 0:
                        {
                            byte[] expr_3B_cp_0 = this.Bgr565Array;
                            int expr_3B_cp_1 = num;
                            expr_3B_cp_0[expr_3B_cp_1] |= (byte)((uint)(argb32Array[offset] & 248) >> 3);
                            break;
                        }
                    case 1:
                        {
                            byte[] arg_59_0 = this.Bgr565Array;
                            int expr_55 = num++;
                            arg_59_0[expr_55] |= (byte)((argb32Array[offset] & 28) << 3);
                            byte[] expr_78_cp_0 = this.Bgr565Array;
                            int expr_78_cp_1 = num;
                            expr_78_cp_0[expr_78_cp_1] |= (byte)((uint)(argb32Array[offset] & 224) >> 5);
                            break;
                        }
                    case 2:
                        {
                            byte[] arg_96_0 = this.Bgr565Array;
                            int expr_92 = num++;
                            arg_96_0[expr_92] |= (byte)(argb32Array[offset] & 248);
                            break;
                        }
                }
                offset++;
                this.argb32Index++;
                count--;
            }
        }

        public new void CopyTo(Stream dest)
        {
            this.CopyToInternal(dest, (int)this.Length - this.argb32Index);
        }

        public new void CopyTo(Stream dest, int bufferSize)
        {
            this.CopyToInternal(dest, (int)this.Length - this.argb32Index);
        }

        private void CopyToInternal(Stream dest, int count)
        {
            int num = this.argb32Index / 2;
            while ((long)this.argb32Index < this.Length && count > 0)
            {
                switch (this.argb32Index % 4)
                {
                    case 0:
                        dest.WriteByte((byte)((Bgr565Array[num] & 31) * 255 / 31));
                        break;
                    case 1:
                        dest.WriteByte((byte)(((this.Bgr565Array[num++] & 224) >> 5 | (int)(this.Bgr565Array[num] & 7) << 3) * 255 / 63));
                        break;
                    case 2:
                        dest.WriteByte((byte)(((this.Bgr565Array[num] & 248) >> 3) * 255 / 31));
                        break;
                    case 3:
                        dest.WriteByte(255);
                        num++;
                        break;
                }
                this.argb32Index++;
                count--;
            }
        }
    }
}
