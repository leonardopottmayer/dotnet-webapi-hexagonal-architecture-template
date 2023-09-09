namespace HexagonalArchitecture.Domain.Contracts
{
    internal interface IValidableFields
    {
        bool FieldsAreValied();
        dynamic ValidateFields();
    }
}
