public static class UserFixture
{
    public static List<User> GetTestUsers() =>
        new List<User>
        {
            new User()
            {
                Id = 1,
                address = new Address()
                {
                    City = "cairo",
                    Id = 1,
                    StreetName = "st9"
                },
                Email = "asd@asd.com",
                UserName = "asd"
            },
            new User()
            {
                Id = 2,
                address = new Address()
                {
                    City = "fayoum",
                    Id = 2,
                    StreetName = "st gamal abd elnaser"
                },
                Email = "asd2@asd.com",
                UserName = "asd2"
            }
        };
}
