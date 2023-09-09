namespace HexagonalArchitecture.Domain.Entities
{
    public class SystemMessage
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool IsEditable { get; set; }

        public SystemMessage() { }
        public SystemMessage(long id, long code, string name, string description, string value, bool isEditable)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Value = value;
            IsEditable = isEditable;
        }
    }
}
