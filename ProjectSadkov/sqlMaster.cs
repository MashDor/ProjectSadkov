using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace ProjectSadkov
{
    class SqlMaster
    {
        private MySqlConnection connection;
        private string SqlString;
        private MySqlCommand command;
        
        public SqlMaster()
        {
            try
            {
                string connStr = "Server=f0480035.xsph.ru;Database=f0480035_pcs71projectdisk;User=f0480035_pcs71projectdisk;Password=pcs147854@;OldGuids=true;";
                connection = new MySqlConnection(connStr);
                connection.Open();
            } catch (Exception e)
            {
                OurMessageBox.Show(
                    "Неудача!", 
                    "Соединение не было установленно.",
                    "Проверте интернет соединение или попробуйте позже.",
                    e.ToString()
                );
            }
        }

        public bool isConnected()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        public string uniqueLogin(string value)
        {
            SqlString = "SELECT name FROM `users` WHERE login = '" + value + "'";
            command = new MySqlCommand(SqlString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                return "Логин уже существует";
            }
            reader.Close();
            return "";
        }

        public string uniqueEmail(string value)
        {
            SqlString = "SELECT name FROM `users` WHERE email = '" + value + "'";
            command = new MySqlCommand(SqlString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                return "Пользователь с таким Email уже зарегистрирован";
            }
            reader.Close();
            return "";
        }

        public string uniquePhone(string value)
        {
            SqlString = "SELECT name FROM `users` WHERE phone = '" + value + "'";
            command = new MySqlCommand(SqlString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                return "Пользователь с таким номером телефона уже зарегистрирован";
            }
            reader.Close();
            return "";
        }

        public void saveUser(string login, string name, string phone, string email, string password)
        {
            try
            {
                if (phone == "+7 (   )    -  -") phone = "";
                SqlString = "INSERT INTO `users` (`user_id`, `login`, `email`, `password`, `name`, `phone`) " +
                            "VALUES (NULL, '" + login + "', '" + email + "', '" + password + "', '" + name + "', '" + phone + "');";
                MySqlCommand command = new MySqlCommand(SqlString, connection);
                command.ExecuteNonQuery();
                OurMessageBox.Show(
                    "Успех!",
                    "Пользователь создан.",
                    "Теперь вы можете авторизироваться."
                );
            } catch (Exception e)
            {
                OurMessageBox.Show(
                    "Не удача!",
                    "Пользователь не был создан.",
                    "Проверте интернет соединение или попробуйте позже.",
                    e.ToString()
                );
            }

        }

        public Boolean userExist(string login, string password)
        {
            SqlString = "SELECT * FROM `users` WHERE login = '" + login + "' AND password = '" + password + "'";
            command = new MySqlCommand(SqlString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }
        public Boolean userExist(string login)
        {
            SqlString = "SELECT * FROM `users` WHERE login = '" + login + "'";
            command = new MySqlCommand(SqlString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public User getUser(string field, string value)
        {
            User user = new User();
            if (field == "login" || field == "email" || field == "phone" || field == "user_id")
            {
                SqlString = "SELECT * FROM `users` WHERE " + field + " = '" + value + "'";
                command = new MySqlCommand(SqlString, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user.userId = reader.GetInt32(0);
                    user.login = reader.GetString(1);
                    user.email = reader.GetString(2);
                    user.password = reader.GetString(3);
                    user.name = reader.GetString(4);
                    user.phone = reader.GetString(5);
                    user.role = reader.GetString(6);
                }
                reader.Close();
            }
            return user;
        }

        public void changePassword(string password, string login)
        {
            try
            {
                if (this.userExist(login))
                {
                    SqlString = "UPDATE `users` SET `password` = '" + password + "' WHERE login = '" + login + "'";
                    MySqlCommand command = new MySqlCommand(SqlString, connection);
                    command.ExecuteNonQuery();
                    OurMessageBox.Show(
                        "Успех.",
                        "Пароль успешно изменен",
                        "Теперь вы можете авторизоваться."
                    );
                }
                else OurMessageBox.Show(
                        "Не удача.",
                        "Не удалось найти пользователя",
                        "Проверте корректость данных."
                    );
            }
            catch
            {
                OurMessageBox.Show(
                        "Не удача!",
                        "Не удалось изменить пароль",
                        "Проверте интернет соединение и повторите попытку позже."
                    );
            }
        }

        ~SqlMaster()
        {
            connection.Close();
        }

    }
}
