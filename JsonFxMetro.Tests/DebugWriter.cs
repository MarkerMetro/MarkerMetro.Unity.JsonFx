using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonFxMetro.Tests
{
    class DebugWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void Write(char value)
        {
            Debug.WriteLine(value);
        }

        public override void Write(string value)
        {
            Debug.WriteLine(value);
        }

        public override void WriteLine()
        {
            Debug.WriteLine("");
        }

        public override void WriteLine(string value)
        {
            Debug.WriteLine(value);
        }

        public override void WriteLine(object value)
        {
            Debug.WriteLine(value);
        }
    }
}
