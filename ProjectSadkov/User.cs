namespace ProjectSadkov
{
    class User
    {
        public int userId;
        public string email;
        public string phone;
        public string name;
        public string password;
        public string role;
        public string login;
        public User(
            int userId,
            string email,
            string phone,
            string name,
            string password,
            string role,
            string login
        )
        {
            this.userId = userId;
            this.email = email;
            this.phone = phone;
            this.name = name;
            this.password = password;
            this.role = role;
            this.login = login;
        }

        public User()
        {
            this.userId = 0;
            this.email = "";
            this.phone = "";
            this.name = "";
            this.password = "";
            this.role = "";
            this.login = "";
        }
    }
}
