using ProtoBuf;

namespace ImageEditor
{
    [ProtoContract]
    public struct Pixel
    {
        [ProtoMember(1)]
        public int X { get; set; }
        
        [ProtoMember(2)]
        public int Y { get; set; }

        [ProtoMember(3)]
        public bool Value { get; set; }
    }
}