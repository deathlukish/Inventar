using FKCPObj.SimleClass;

namespace FKCPObj
{
    public class SimpleFN
    {
        private readonly ulong _NumFn;
        private readonly string? _Model;
        private readonly DateOnly _DateBlock;
        private bool _Status;
        private byte _RegType;
        private readonly float _FDVer;
        private List<RegDoc>? _regDocs;
        private Action<string>? _Message;
        public SimpleFN(ulong NumFn, string Model, DateOnly DateBlock, bool Status, byte RegType, List<RegDoc> RegDocs, Action<string> action)
        { 
            _NumFn = NumFn;
            _Model = Model;
            _Status = Status;
            _RegType = RegType;
            _DateBlock = DateBlock;
            _Status = Status;
            _regDocs = RegDocs;
            _Message = action;
        }
        public SimpleFN(ulong NumFn) : this(NumFn, "", default, true, 0, default, default)
        { }
    }
}