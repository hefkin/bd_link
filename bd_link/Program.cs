using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace db
{
    struct qwe
    {
        public string id;
        public string person;
        public string number;
    }

    class Program
    {

        MySqlConnection asd;

        public List<qwe> kek()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.Server = "localhost";
            stringBuilder.UserID = "root";
            stringBuilder.Database = "mainbd";
            stringBuilder.SslMode = MySqlSslMode.None;
            asd = new MySqlConnection(stringBuilder.ConnectionString);

            MySqlCommand command = asd.CreateCommand();
            Console.WriteLine("Введите команду: ");
            string request1 = Console.ReadLine();
            command.CommandText = request1;

            List<qwe> bd = new List<qwe>();

            try
            {
                asd.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        qwe databd = new qwe
                        {
                            id = reader.GetString(0),
                            person = reader.GetString(1),
                            number = reader.GetString(2),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bd;
        }
        static void Main(string[] args)
        {
            Program request1 = new Program();
            var Maki = request1.kek();
            foreach (var data in Maki)
            {
                Console.WriteLine(data.id + " | " + data.person.PadRight(10) + " | " + data.number.PadRight(10));
            }
            Console.ReadLine();
        }
    }
}
