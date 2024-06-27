namespace OutOfOffice.DOMAIN
{
    public enum CustomExceptionType
    {
        InternalError = 1,
        NoContent = 2,
        NotFound = 3,
        InvalidInputData = 4,
        UserIsAlreadyExists = 5,

        AbsenceReasonAlreadyExists = 21,
        EmployeeAlreadyExists = 22,
        PositionAlreadyExists = 23,
        ProjectAlreadyExists = 24,
        RoleAlreadyExists = 25,
        ProjectTypeAlreadyExists = 26,
        SubdivisionAlreadyExists = 27,

        EmployeeStatusAlreadyExists = 31,
        ProjectStatusAlreadyExists = 32,
        RequestStatusAlreadyExists = 33
    }
}
