using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;
using Pathfinding.Serialization.JsonFx;

namespace JsonFxMetro.Tests
{
    [TestClass]
    public class PathfindingTests
    {

        public struct Guid
        {
            const string hex = "0123456789ABCDEF";

            public static readonly Guid zero = new Guid(new byte[16]);
            public static readonly string zeroString = new Guid(new byte[16]).ToString();

            private ulong _a, _b;

            public Guid(byte[] bytes)
            {
                _a = ((ulong)bytes[0] << 8 * 0) |
                    ((ulong)bytes[1] << 8 * 1) |
                    ((ulong)bytes[2] << 8 * 2) |
                    ((ulong)bytes[3] << 8 * 3) |
                    ((ulong)bytes[4] << 8 * 4) |
                    ((ulong)bytes[5] << 8 * 5) |
                    ((ulong)bytes[6] << 8 * 6) |
                    ((ulong)bytes[7] << 8 * 7);

                _b = ((ulong)bytes[8] << 8 * 0) |
                    ((ulong)bytes[9] << 8 * 1) |
                    ((ulong)bytes[10] << 8 * 2) |
                    ((ulong)bytes[11] << 8 * 3) |
                    ((ulong)bytes[12] << 8 * 4) |
                    ((ulong)bytes[13] << 8 * 5) |
                    ((ulong)bytes[14] << 8 * 6) |
                    ((ulong)bytes[15] << 8 * 7);

                /*b1 = bytes[1];
                b2 = bytes[2];
                b3 = bytes[3];
                b4 = bytes[4];
                b5 = bytes[5];
                b6 = bytes[6];
                b7 = bytes[7];
                b8 = bytes[8];
                b9 = bytes[9];
                b10 = bytes[10];
                b11 = bytes[11];
                b12 = bytes[12];
                b13 = bytes[13];
                b14 = bytes[14];
                b15 = bytes[15];*/
            }

            public Guid(string str)
            {
                /*b0 = 0;
                b1 = 0;
                b2 = 0;
                b3 = 0;
                b4 = 0;
                b5 = 0;
                b6 = 0;
                b7 = 0;
                b8 = 0;
                b9 = 0;
                b10 = 0;
                b11 = 0;
                b12 = 0;
                b13 = 0;
                b14 = 0;
                b15 = 0;*/

                _a = 0;
                _b = 0;

                if (str.Length < 32)
                    throw new System.FormatException("Invalid Guid format");

                int counter = 0;
                int i = 0;
                int offset = 15 * 4;

                for (; counter < 16; i++)
                {
                    if (i >= str.Length)
                        throw new System.FormatException("Invalid Guid format. String too short");

                    char c = str[i];
                    if (c == '-') continue;

                    //Neat trick, perhaps a bit slow, but one will probably not use Guid parsing that much
                    int value = hex.IndexOf(char.ToUpperInvariant(c));
                    if (value == -1)
                        throw new System.FormatException("Invalid Guid format : " + c + " is not a hexadecimal character");

                    _a |= (ulong)value << offset;
                    //SetByte (counter,(byte)value);
                    offset -= 4;
                    counter++;
                }

                offset = 15 * 4;
                for (; counter < 32; i++)
                {
                    if (i >= str.Length)
                        throw new System.FormatException("Invalid Guid format. String too short");

                    char c = str[i];
                    if (c == '-') continue;

                    //Neat trick, perhaps a bit slow, but one will probably not use Guid parsing that much
                    int value = hex.IndexOf(char.ToUpperInvariant(c));
                    if (value == -1)
                        throw new System.FormatException("Invalid Guid format : " + c + " is not a hexadecimal character");

                    _b |= (ulong)value << offset;
                    //SetByte (counter,(byte)value);
                    offset -= 4;
                    counter++;
                }
            }

            public static Guid Parse(string input)
            {
                return new Guid(input);
            }

            public byte[] ToByteArray()
            {
                byte[] bytes = new byte[16];
                byte[] ba = System.BitConverter.GetBytes(_a);
                byte[] bb = System.BitConverter.GetBytes(_b);

                for (int i = 0; i < 8; i++)
                {
                    bytes[i] = ba[i];
                    bytes[i + 8] = bb[i];

                }
                return bytes;
            }

            private static System.Random random = new System.Random();

            public static Guid NewGuid()
            {
                byte[] bytes = new byte[16];
                random.NextBytes(bytes);
                return new Guid(bytes);
            }

            public static bool operator ==(Guid lhs, Guid rhs)
            {
                return lhs._a == rhs._a && lhs._b == rhs._b;
            }

            public static bool operator !=(Guid lhs, Guid rhs)
            {
                return lhs._a != rhs._a || lhs._b != rhs._b;
            }

            public override bool Equals(System.Object _rhs)
            {
                if (!(_rhs is Guid)) return false;

                Guid rhs = (Guid)_rhs;

                return this._a == rhs._a && this._b == rhs._b;
            }

            public override int GetHashCode()
            {
                ulong ab = _a ^ _b;
                return (int)(ab >> 32) ^ (int)ab;
            }

            private static System.Text.StringBuilder text;

            public override string ToString()
            {
                if (text == null)
                {
                    text = new System.Text.StringBuilder();
                }
                lock (text)
                {
                    text.Length = 0;
                    text.Append(_a.ToString("x16")).Append('-').Append(_b.ToString("x16"));
                    return text.ToString();
                }
            }
        }

        public abstract class NavGraph
        {
            public byte[] _sguid;

            /** Used as an ID of the graph, considered to be unique.
             * \note This is Pathfinding.Util.Guid not System.Guid. A replacement for System.Guid was coded for better compatibility with iOS
             */
            [JsonMember]
            public Guid guid
            {
                get
                {
                    if (_sguid == null || _sguid.Length != 16)
                    {
                        _sguid = Guid.NewGuid().ToByteArray();
                    }
                    return new Guid(_sguid);
                }
                set
                {
                    _sguid = value.ToByteArray();
                }
            }

            [JsonMember]
            public uint initialPenalty = 0;
            [JsonMember]
            public bool open;
            [JsonMember]
            public string name;
            [JsonMember]
            public bool drawGizmos = true;
            [JsonMember]
            public bool infoScreenOpen;

            //[JsonMember]
            //public Matrix4x4 matrix;

            ///** Inverse of \a matrix.
            // * 
            // * \note Do not set directly, use SetMatrix
            // */
            //public Matrix4x4 inverseMatrix;
        }

        public class GridGraph : NavGraph
        {

        }

        public class GuidConverter : JsonConverter
        {
            public override bool CanConvert(Type type)
            {
                return type == typeof(Guid);
            }

            public override object ReadJson(Type objectType, Dictionary<string, object> values)
            {

                string s = (string)values["value"];
                return new Guid(s);
            }

            public override Dictionary<string, object> WriteJson(Type type, object value)
            {
                Guid m = (Guid)value;
                return new Dictionary<string, object>() { { "value", m.ToString() } };
            }
        }

        [TestMethod]
        public void ShouldFillObject_FromAStarWACKTest2SerializedJson_GuidCorrectly()
        {
            var data = "{\"guid\":{\"value\":\"462c822a5bde4f2a-d776405ec65de86f\"},\"aspectRatio\":1,\"rotation\":{\"x\":0,\"y\":0,\"z\":0},\"center\":{\"x\":0,\"y\":-0.1,\"z\":0},\"unclampedSize\":{\"x\":100,\"y\":100},\"nodeSize\":1,\"collision\":{\"type\":\"Capsule\",\"diameter\":1,\"height\":2,\"collisionOffset\":0,\"rayDirection\":\"Both\",\"mask\":{\"value\":512},\"heightMask\":{\"value\":256},\"fromHeight\":100,\"thickRaycast\":false,\"thickRaycastDiameter\":1,\"up\":{\"x\":0,\"y\":1,\"z\":0},\"collisionCheck\":true,\"heightCheck\":true,\"unwalkableWhenNoGround\":true,\"use2D\":false},\"maxClimb\":0.4,\"maxClimbAxis\":1,\"maxSlope\":90,\"erodeIterations\":0,\"erosionUseTags\":false,\"erosionFirstTag\":1,\"autoLinkGrids\":false,\"autoLinkDistLimit\":10,\"neighbours\":\"Eight\",\"cutCorners\":true,\"penaltyPositionOffset\":0,\"penaltyPosition\":false,\"penaltyPositionFactor\":1,\"penaltyAngle\":false,\"penaltyAngleFactor\":100,\"textureData\":{\"enabled\":false,\"source\":null,\"factors\":[0,0,0],\"channels\":[\"None\",\"None\",\"None\"]},\"initialPenalty\":0,\"open\":true,\"name\":\"Grid Graph\",\"drawGizmos\":true,\"infoScreenOpen\":false,\"matrix\":{\"values\":[1,0,0,0,0,1,0,0,0,0,1,0,-50,-0.1,-50,1]}}";

            var target = new GridGraph();
            var readerSettings = new JsonReaderSettings();
            readerSettings.AddTypeConverter(new GuidConverter());

            var serializer = new Pathfinding.Serialization.JsonFx.JsonReader(data, readerSettings);
            serializer.PopulateObject(target);

            var expected = new Guid("462c822a5bde4f2a-d776405ec65de86f");
            Assert.AreEqual(expected, target.guid);
        }
    }
}
