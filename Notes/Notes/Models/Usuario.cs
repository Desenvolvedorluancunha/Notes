using System;
using SQLite;



namespace Notes.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NOME_USUARIO { get; set; }
        public string SENHA_USUARIO { get; set; }
    }
}
