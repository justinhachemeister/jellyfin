using System;
using System.IO;
using System.Net.Sockets;

namespace SocketHttpListener
{
    public class SocketStream : Stream
    {
        private readonly Socket _socket;

        public SocketStream(Socket socket, bool ownsSocket)
        {
            _socket = socket;
        }

        public override void Flush()
        {
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotImplementedException();

        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _socket.Send(buffer, offset, count, SocketFlags.None);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _socket.BeginSend(buffer, offset, count, SocketFlags.None, callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            _socket.EndSend(asyncResult);
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _socket.Receive(buffer, offset, count, SocketFlags.None);
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _socket.BeginReceive(buffer, offset, count, SocketFlags.None, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return _socket.EndReceive(asyncResult);
        }
    }
}
