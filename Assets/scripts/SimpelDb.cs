using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class SimpelDb : MonoBehaviour
{
    protected static string dbname = "URI=file:mydb.db";
    static SqliteConnection connection = new SqliteConnection(dbname);
    static SqliteCommand command = connection.CreateCommand();

    void Start()
    {
       
        creatdB();

    }
    void creatdB()
    {
        
        connection.Open();
        
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "CREATE TABLE IF NOT EXISTS 'highscores' ('score' INTEGER NOT NULL);";
        command.ExecuteNonQuery();
        connection.Close();
    }

    public static void update(int heigscore)
    {
        connection.Open();
        command.CommandText = @"UPDATE highscores SET score = $heigscore;";
        command.Parameters.AddWithValue("$heigscore", heigscore);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public static string read()
    {
        string rd;
        connection.Open();
        command.CommandText = "SELECT score FROM highscores;";
        IDataReader reader = command.ExecuteReader();
        rd = reader["score"].ToString();
        reader.Close();
        command.ExecuteNonQuery();
        connection.Close();
        return (rd);
    }
}