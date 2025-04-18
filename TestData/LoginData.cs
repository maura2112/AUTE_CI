public class LoginData
{
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    private LoginData() { }

    public static LoginDataBuilder Builder() => new LoginDataBuilder();

    public class LoginDataBuilder
    {
        private readonly LoginData _data = new();

        public LoginDataBuilder WithUsername(string username) { _data.Username = username; return this; }

        public LoginDataBuilder WithPassword(string password) { _data.Password = password; return this; }

        public LoginData Build() => _data;
    }

    public static LoginData ValidUser() =>
        Builder().WithUsername("Admin2").WithPassword("Fxu1tw^E").Build();
    public static LoginData InvalidUser() =>
            Builder().WithUsername("Admin1").WithPassword("Fxu1tw^3").Build();
    public static LoginData EmptyPassword() =>
        Builder().WithUsername("Admin2").Build();
    public static LoginData EmptyUserName() =>
    Builder().WithPassword("Fxu1tw^E").Build();
    public static LoginData EmptyUser() =>
    Builder().Build();

}