namespace OutOfOffice.DOMAIN
{
    public static class SeedConstants
    {

        public const int NUMBER_OF_ADMIN = 1;

        public const int NUMBER_OF_APP_USERS = 100;

        public const int NUMBER_OF_HR_MANAGERS = 10;

        public const int NUMBER_OF_PROJECT_MANAGERS = 15;

        public const int NUMBER_OF_EMPLOYEE = NUMBER_OF_APP_USERS - NUMBER_OF_HR_MANAGERS - NUMBER_OF_PROJECT_MANAGERS;

        public const int MIN_OUT_OF_OFFICE_BALANCE = 15;

        public const int MAX_OUT_OF_OFFICE_BALANCE = 25;

        public const int NUMBER_OF_PROJECTS = 15;

        public const int NUMBER_OF_LEAVE_REQUESTS = 50;

        public const int NUMBER_OF_APPROVAL_REQUESTS = 50;

    }
}