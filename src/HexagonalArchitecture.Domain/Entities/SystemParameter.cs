namespace HexagonalArchitecture.Domain.Entities
{
    public class SystemParameter
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public char Type { get; set; }
        public string Value { get; set; }
        public bool IsEditable { get; set; }

        public SystemParameter() { }
        public SystemParameter(long id, long code, string name, string description, char type, string value, bool isEditable)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Type = type;
            Value = value;
            IsEditable = isEditable;
        }
    }
}
